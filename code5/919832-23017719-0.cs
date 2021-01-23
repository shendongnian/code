        public List<string> GetStudents(string filename)
        {
            List<string> students = new List<string>();
            StringBuilder builder = new StringBuilder();
            using (StreamReader reader = new StreamReader(filename)){
                string line = "";
                while (!reader.EndOfStream)
                {
                    line  = reader.ReadLine();
                    if (line.StartsWith("student ID") && builder.Length > 0)
                    {
                        students.Add(builder.ToString());
                        builder.Clear();
                        builder.Append(line);
                        continue;
                    }
                    builder.Append(line);
                }
                if (builder.Length > 0)
                    students.Add(builder.ToString());
            }
            return students;
        }
