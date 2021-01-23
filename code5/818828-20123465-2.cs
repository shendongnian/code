                String[] lines = System.IO.File.ReadAllLines("myfile.txt");
                String[] newLines = new String[lines.Length];
                int i=0;
                foreach (String line in lines)
                {
                    newLines[i]=(line.Contains(">"))?line.Split('>')[1]:line;
                     i++;
                }
                System.IO.File.WriteAllLines("myfile.txt",newLines);
