                String path=@"D:\Ed\10\rep\Demo.txt";
                System.IO.File.WriteAllText(path, string.Empty);
                using (StreamWriter file2 = new StreamWriter(path, true))
                {
                    file2.WriteLine("Demo");
                }
                if (System.IO.File.Exists(path))
                    System.IO.File.Copy(path, @"D:\Demo.htm", true);
