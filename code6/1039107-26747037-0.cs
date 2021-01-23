    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace FilesReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = args[0];
                RunTrial(path, false);
                RunTrial(path, true);
            }
            
            private static void RunTrial(string path, bool useParallel)
            {
                Console.WriteLine("Parallel: {0}", useParallel);
    
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                FileListing listing = new FileListing(path, useParallel);
                stopwatch.Stop();
    
                Console.WriteLine("Added {0} files in {1} ms ({2} file/second)", 
                    listing.Files.Count, stopwatch.ElapsedMilliseconds, 
                    (listing.Files.Count * 1000 / stopwatch.ElapsedMilliseconds));
            }
        }
    
        class FileListing
        {
            private ConcurrentList<string> _files;
            private bool _parallelExecution;
             
            public FileListing(string path, bool parallelExecution)
            {
                _parallelExecution = parallelExecution;
                _files = new ConcurrentList<string>();
                BuildListing(path);
            }
    
            public ConcurrentList<string> Files
            {
                get { return _files; }
            }
    
            private void BuildListing(string path)
            {
                string[] dirs = null;
                string[] files = null;
                bool success = false;
    
                try
                {
                    dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                    files = Directory.GetFiles(path);
                    success = true;
                }
                catch (SystemException) { /* Suppress security exceptions etc*/ }
    
                if (success)
                {
                    Files.AddRange(files);
    
                    if (_parallelExecution)
                    {
                        Parallel.ForEach(dirs, d => BuildListing(d));
                    }
                    else
                    {
                        foreach (string dir in dirs)
                        {
                            BuildListing(dir);
                        }
                    }
                }
            }
        }
    
        class ConcurrentList<T>
        {
            object lockObject = new object();
            List<T> list;
    
            public ConcurrentList()
            {
                list = new List<T>();
            }
    
            public void Add(T item)
            {
                lock (lockObject) list.Add(item);
    
            }
            public void AddRange(IEnumerable<T> collection)
            {
                lock (lockObject) list.AddRange(collection);
            }
    
            public long Count
            {
                get { lock (lockObject) return list.Count; }
            }
        }
    }
