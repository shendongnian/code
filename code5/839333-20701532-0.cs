        private string[] ParseLine(string line)
        {
            List<string> results = new List<string>();
            bool inQuotes = false;
            int index = 0;
            StringBuilder currentValue = new StringBuilder(line.Length);
            while (index < line.Length)
            {
                char c = line[index];
                switch (c)
                {
                    case '\"':
                        {
                            inQuotes = !inQuotes;
                            break;
                        }
                    default:
                        {
                            if (c == ',' && !inQuotes)
                            {
                                results.Add(currentValue.ToString());
                                currentValue.Clear();
                            }
                            else
                                currentValue.Append(c);
                            break;
                        }
                }
                ++index;
            }
            results.Add(currentValue.ToString());
            return results.ToArray();
        }   // eo ParseLine
