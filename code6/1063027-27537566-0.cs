    int count = 0;
                DirectoryInfo diTop = new DirectoryInfo(@"c:\");
                try
                {
                    foreach (var fi in diTop.EnumerateFiles())
                    {
                        try
                        {
                            count++;
                        }
                        catch (UnauthorizedAccessException UnAuthTop)
                        {
                            Console.WriteLine("{0}", UnAuthTop.Message);
                        }
                    }
    
                    foreach (var di in diTop.EnumerateDirectories("*"))
                    {
                        try
                        {
                            foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
                            {
                                try
                                {
                                    count++;
                                }
                                catch (UnauthorizedAccessException UnAuthFile)
                                {
                                    Console.WriteLine("UnAuthFile: {0}", UnAuthFile.Message);
                                }
                            }
                        }
                        catch (UnauthorizedAccessException UnAuthSubDir)
                        {
                            Console.WriteLine("UnAuthSubDir: {0}", UnAuthSubDir.Message);
                        }
                    }
                }
                catch (DirectoryNotFoundException DirNotFound)
                {
                    Console.WriteLine("{0}", DirNotFound.Message);
                }
                catch (UnauthorizedAccessException UnAuthDir)
                {
                    Console.WriteLine("UnAuthDir: {0}", UnAuthDir.Message);
                }
                catch (PathTooLongException LongPath)
                {
                    Console.WriteLine("{0}", LongPath.Message);
                }
    
                Console.WriteLine(count);
                Console.ReadLine();
            }
