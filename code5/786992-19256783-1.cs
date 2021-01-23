            string path="filePath";
            if (System.IO.File.Exists(path))
                using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
                {
                    while (sr.Peek() > -1)
                        Console.WriteLine(sr.ReadLine());
                }
            else
                Console.WriteLine("The file not exist!");
