    using Microsoft.Win32;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace RegistryMonitor
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                GenerateRegistrySnapshot("Snapshot.sqlite");
                Console.ReadLine();   
            }
    
            static object writeLock = new object();
            static AutoResetEvent writeReady = new AutoResetEvent(false);
            static AutoResetEvent writeCompleted = new AutoResetEvent(false);
            static RegistryPath pathToWrite;
    
            static void GenerateRegistrySnapshot(string filename)
            {
                File.Delete(filename);
                SQLiteConnection.CreateFile(filename);
                bool finished = false;
                Thread worker = new Thread(() =>
                {
                    using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
                    {
                        connection.Open();
                        CreateTable(connection);
                        SQLiteTransaction transaction = connection.BeginTransaction();
                        while (!finished)
                        {
                            writeReady.WaitOne();
                            if (finished)
                            {
                                break;
                            }
                            AddEntry(connection, pathToWrite);
                            writeCompleted.Set();
                        }
                        transaction.Commit();
                        transaction.Dispose();
                        connection.Close();
                    }
                });
                worker.Start();
                Stopwatch watch = new Stopwatch();
                Console.WriteLine("Started walking the registry into file {0}.", filename);
                watch.Start();
                WalkTheRegistryAndPopulateTheSnapshot();
                finished = true;
                writeReady.Set();
                worker.Join();
                watch.Stop();
                Console.WriteLine("Finished walking the registry in {0} seconds.", watch.Elapsed.TotalSeconds);
            }
    
            static void CreateTable(SQLiteConnection connection)
            {
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE Snapshot (ID INTEGER PRIMARY KEY AUTOINCREMENT, RegistryView INTEGER NULL, Path TEXT NULL, IsKey BOOLEAN NULL, RegistryValueKind INTEGER NULL, ValueName TEXT NULL, Value BLOB NULL, HashValue INTEGER NULL)", connection);
                command.ExecuteNonQuery();
            }
    
            static void AddEntry(SQLiteConnection connection, RegistryPath path)
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO Snapshot (RegistryView, Path, IsKey, RegistryValueKind, ValueName, Value, HashValue) VALUES (@RegistryView, @Path, @IsKey, @RegistryValueKind, @ValueName, @Value, @HashValue)", connection);
                command.Parameters.Add("@RegistryView", DbType.Int32).Value = path.View;
                command.Parameters.Add("@Path", DbType.String).Value = path.Path;
                command.Parameters.Add("@IsKey", DbType.Boolean).Value = path.IsKey;
                command.Parameters.Add("@RegistryValueKind", DbType.Int32).Value = path.ValueKind;
                command.Parameters.Add("@ValueName", DbType.String).Value = path.ValueName;
                command.Parameters.Add("@Value", DbType.Object).Value = path.Value;
                command.Parameters.Add("@HashValue", DbType.Int32).Value = path.HashValue;
                command.ExecuteNonQuery();
            }
    
            private static void WalkTheRegistryAndPopulateTheSnapshot()
            {
                List<ManualResetEvent> handles = new List<ManualResetEvent>();
                foreach (RegistryHive hive in Enum.GetValues(typeof(RegistryHive)))
                {
                    foreach (RegistryView view in Enum.GetValues(typeof(RegistryView)).Cast<RegistryView>().ToList().Where(x => x != RegistryView.Default))
                    {
                        ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                        handles.Add(manualResetEvent);
                        new Thread(() =>
                        {
                            WalkKey(view, RegistryKey.OpenBaseKey(hive, view));
                            manualResetEvent.Set();
                        }).Start();
                    }
                }
                ManualResetEvent.WaitAll(handles.ToArray());
            }
    
            private static void WalkKey(RegistryView view, RegistryKey key)
            {
                RegistryPath path = new RegistryPath(view, key.Name);
                Write(path);
                string[] valueNames = null;
                try
                {
                    valueNames = key.GetValueNames();
                }
                catch { }
                if (valueNames != null)
                {
                    foreach (string valueName in valueNames)
                    {
                        RegistryValueKind valueKind = RegistryValueKind.Unknown;
                        try
                        {
                            valueKind = key.GetValueKind(valueName);
                        }
                        catch { }
                        object value = key.GetValue(valueName);
                        RegistryPath pathForValue = new RegistryPath(view, key.Name, valueKind, valueName, value);
                        Write(pathForValue);
                    }
                }
                string[] subKeyNames = null;
                try
                {
                    subKeyNames = key.GetSubKeyNames();
                }
                catch { }
                if (subKeyNames != null)
                {
                    foreach (string subKeyName in subKeyNames)
                    {
                        try
                        {
                            WalkKey(view, key.OpenSubKey(subKeyName));
                        }
                        catch { }
                    }
                }
            }
    
            private static void Write(RegistryPath path)
            {
                lock (writeLock)
                {
                    pathToWrite = path;
                    writeReady.Set();
                    writeCompleted.WaitOne();
                }
            }
    
            class RegistryPath
            {
                public RegistryView View;
                public string Path;
                public bool IsKey;
                public RegistryValueKind ValueKind;
                public string ValueName;
                public object Value;
                public int HashValue;
    
                public RegistryPath(RegistryView view, string path)
                {
                    View = view;
                    Path = path;
                    IsKey = true;
                    HashValue = (view.GetHashCode() ^ path.GetHashCode()).GetHashCode();
                }
    
                public RegistryPath(RegistryView view, string path, RegistryValueKind valueKind, string valueName, object value)
                {
                    View = view;
                    Path = path;
                    IsKey = false;
                    ValueKind = valueKind;
                    ValueName = valueName;
                    Value = value;
                    if (value != null)
                    {
                        HashValue = (view.GetHashCode() ^ path.GetHashCode() ^ valueKind.GetHashCode() ^ valueName.GetHashCode() ^ value.GetHashCode()).GetHashCode();
                    }
                    else
                    {
                        HashValue = (view.GetHashCode() ^ path.GetHashCode() ^ valueKind.GetHashCode() ^ valueName.GetHashCode()).GetHashCode();
                    }
                }
            }
        }
    }
