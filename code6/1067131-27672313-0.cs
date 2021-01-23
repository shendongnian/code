       DirectoryInfo folderInfo = new DirectoryInfo(@"C:\test");
            FileInfo[] files = folderInfo.GetFiles();
            long[] sort = new long[files.Length];
            for (int largestSize = 0; largestSize < files.Length; largestSize++)
            {
                int index = 0;
                for (int largestSize2 = 0; largestSize2 < files.Length; largestSize2++)
                {
                    if (files[largestSize].Length < files[largestSize2].Length)
                    {
                        index++;
                    }
                  
                }  
                sort[index] = files[largestSize].Length;
              
            }
            for (int i = 0; i < sort.Length; i++)
            {
                Console.WriteLine(sort[i]);
            }
            Console.ReadLine();
