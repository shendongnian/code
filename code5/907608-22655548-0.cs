                string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = pathDesktop + "\\mycsvfile.csv";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string delimter = ",";
            string[][] output = new string[][] { 
                new string[] {"TEST1","TEST2"},
                new string[] {"TES3","TEST4"}
                };
            int length = output.GetLength(0);
            using (System.IO.TextWriter writer = File.CreateText(filePath))
            {
                for (int index = 0; index < length; index++)
                {
                    writer.WriteLine(string.Join(delimter, output[index]));
                }
            }
