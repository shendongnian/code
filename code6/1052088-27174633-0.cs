                var filePath = //your file path
                var test = File.ReadAllLines(filePath);
                var sb = new StringBuilder();
                for (int i = 0; i < (test.Length - 1); i++)
                {
                    sb.Append(test[i]);
                    sb.Append(Environment.NewLine);
                    if (test[i].Contains("my"))
                    {
                        // This adds that extra new line
                        sb.Append(Environment.NewLine);
                    }
                }
                sb.Append(test[test.Length-1]);
    
                File.WriteAllText(filePath,  sb.ToString());
