             var paths = new List<string>
            {
               Environment.SystemDirectory,
               Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
               Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
               Environment.GetFolderPath(Environment.SpecialFolder.Programs),
            };
            foreach (string path in paths)
            {
                var ser = Search("java.exe", path);
                if (ser.Any())
                {
                    foreach (string s in ser)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
