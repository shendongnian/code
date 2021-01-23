    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using SchwabenCode.QuickIO;
    
    namespace ConsoleApplication3
    {
        internal class Program
        {
            private static readonly BlockingCollection<QuickIOFileInfo> fileInfos = new BlockingCollection<QuickIOFileInfo>();
            private static void Main(string[] args)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    Int32 totalSize = 0;
                    Parallel.ForEach(fileInfos.GetConsumingEnumerable(), fi =>
                    {
                        Interlocked.Add(ref totalSize, (int)fi.Bytes);
                    });
                    Console.WriteLine("All docs bytes amount to {0}", totalSize);
                });
    
                ProcessDirectory("C:\\");
                fileInfos.CompleteAdding();
    
                Task.WaitAll(task);
            }
    
            private static void ProcessDirectory(string path)
            {
                Parallel.ForEach(QuickIODirectory.EnumerateDirectories(path), dir =>
                {
                    try
                    {
                        Parallel.ForEach(QuickIODirectory.EnumerateFiles(dir), file =>
                        {
                            if (file.AsFileInfo().Extension.Equals(".docx"))
                                fileInfos.Add(file);
                        });
                        ProcessDirectory(dir.FullName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unable to access directory {0}", dir.FullName);
                    }
                });
            }
        }
    }
