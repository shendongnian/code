        public void Method()
        {
            string originPath = "";
            string savePath = "";
            string[] lines = File.ReadAllLines(originPath);
            using (StreamWriter writer = new StreamWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
            {
                foreach (string line in lines)
                {
                    string digits = line.Substring(0, 3);   //If you are sure it will always be 3 digits.
                    digits = line.Split('^').FirstOrDefault();
                    if (digits != null)
                    {
                        writer.WriteLine(digits);
                    }
                }
                writer.Flush();
                writer.Close();
            }
        }
