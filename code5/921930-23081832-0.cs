        public string[] GetLines()
        {
            List<string> lines = new List<string>();
            bool startRead = false;
            string uniqueString = "uniqueString";
            using (StreamReader st = new StreamReader("File.txt"))
            {
                while (!st.EndOfStream)
                {
                    if (!startRead && st.ReadLine().Equals(uniqueString))
                        startRead = true;
                    if (!startRead)
                        continue;
                    lines.Add(st.ReadLine());
                }
            }
            return lines.ToArray();
        }
