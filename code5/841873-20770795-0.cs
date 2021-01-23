            string path = @"C:\Data.txt";
            string[] lines = File.ReadAllLines(path);
            String strRemove = "8971820518";
            List<String> lst = new List<String>();
            for(int i=0;i<lines.Length;i++)
            {
                if (!lines[i].Equals(strRemove))  //if string is part of line use Contains()
                {
                    lst.Add(lines[i]);
                }
            }
            File.WriteAllLines(path,lst.ToArray());
