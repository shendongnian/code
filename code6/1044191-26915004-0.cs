    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                long size = fetchFolderSize(@"C:\Test", new CancellationTokenSource());
    
            }
    
                public static long fetchFolderSize(string Folder, CancellationTokenSource  oCancelToken)
        {
                
    
                ParallelOptions po = new ParallelOptions();
                po.CancellationToken = oCancelToken.Token;
                po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
    
                long folderSize = 0;
                string[] files = Directory.GetFiles(Folder);
        
                Parallel.ForEach<string,long>(files,
                                                po,
                                                () => 0,
                                                (fileName, loop, fileSize) => 
                                                {
                                                    fileSize = new FileInfo(fileName).Length;
                                                    po.CancellationToken.ThrowIfCancellationRequested();
                                                    return fileSize;
    
                                                },  
                                                (finalResult) => Interlocked.Add(ref folderSize, finalResult)
                                                );
                   
        
                string[] subdirEntries = Directory.GetDirectories(Folder);
        
                Parallel.For<long>(0, subdirEntries.Length, () => 0, (i, loop, subtotal) =>
                {
                    if ((File.GetAttributes(subdirEntries[i]) & FileAttributes.ReparsePoint) !=
                          FileAttributes.ReparsePoint)
                        {
                            subtotal += fetchFolderSize(subdirEntries[i], oCancelToken);
                            return subtotal;
                        }
                        return 0;
                    },
                        (finalResult) => Interlocked.Add(ref folderSize, finalResult)
                    );
                
                return folderSize ;
        }
        }
    
    }
