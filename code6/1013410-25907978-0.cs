    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            private static DirWithSubDirs RootDir;
            private static void Main()
            {
                Console.WriteLine("Loading file system into memory...");
                RootDir = new DirWithSubDirs("Root", 4, 4);
                Console.WriteLine("Done");
                //ThreadPool.SetMinThreads(4000, 16);
                //ThreadPool.SetMaxThreads(4000, 16);
                var w = Stopwatch.StartNew();
                ThisIsARecursiveFunctionInMemory(RootDir);
                Console.WriteLine("Elapsed seconds: " + w.Elapsed.TotalSeconds);
                Console.ReadKey();
            }
            public static void ThisIsARecursiveFunctionInMemory(DirWithSubDirs currentDirectory)
            {
                var depth = currentDirectory.Path.Count(t => t == '\\');
                Console.WriteLine(depth + ": " + currentDirectory.Path);
                var children = currentDirectory.SubDirs;
                //Edit this mode to switch what way of parallelization it should use
                int mode = 3;
                switch (mode)
                {
                    case 1:
                        foreach (var child in children)
                        {
                            ThisIsARecursiveFunctionInMemory(child);
                        }
                        break;
                    case 2:
                        children.AsParallel().ForAll(t =>
                        {
                            ThisIsARecursiveFunctionInMemory(t);
                        });
                        break;
                    case 3:
                        Parallel.ForEach(children, t =>
                        {
                            ThisIsARecursiveFunctionInMemory(t);
                        });
                        break;
                    default:
                        break;
                }
            }
        }
        internal class DirWithSubDirs
        {
            public List<DirWithSubDirs> SubDirs = new List<DirWithSubDirs>();
            public String Path { get; private set; }
            public DirWithSubDirs(String path, int width, int depth)
            {
                this.Path = path;
                if (depth > 0)
                    for (int i = 0; i < width; ++i)
                        SubDirs.Add(new DirWithSubDirs(path + "\\" + i, width, depth - 1));
            }
        }
    }
