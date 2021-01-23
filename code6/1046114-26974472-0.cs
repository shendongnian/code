        public IDictionary<string, string> ReadFromFile(string fileName)
        {
            var result = new Dictionary<string, string>();
            using (var file = new StreamReader(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var values = line.Split(':');
                    if (values.Length == 2)
                    {
                        result[values[0].Trim()] = values[1].Trim();
                    }
                }
            }
            return result;
        }
