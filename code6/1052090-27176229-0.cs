            string path = @"c:\some\path\file.txt";
            List<String> lines = new List<string>(System.IO.File.ReadAllLines(path));
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains("my"))
                {
                    if (i < lines.Count -1)
                    {
                        lines.Insert(i + 1, "");
                    }
                    else
                    {
                        lines.Add("");
                    }
                }
            }
            System.IO.File.WriteAllLines(path, lines.ToArray());
