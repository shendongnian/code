            string path = @"C:\Data.txt";
            string[] lines = File.ReadAllLines(path);
            int  iRemoveLineNo = 6;
            List<String> lst = new List<String>();
            for(int i=0;i<lines.Length;i++)
            {
                if (iRemoveLineNo-1!=i)
                {
                    lst.Add(lines[i]);
                }
            }
            File.WriteAllLines(path,lst.ToArray());
