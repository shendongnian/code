       List<int> data = new List<int>();
            using (StreamReader xReader = new StreamReader("TextFile1.txt"))
            {
                string line;
                while (!xReader.EndOfStream)
                {
                    line = xReader.ReadLine();
                    string[] input = line.Split(' ', '\r');// this splits the line on the space and newline
                    foreach (string item in input)
                    {
                        data.Add(Convert.ToInt32(item));
                    }
                }
            }
