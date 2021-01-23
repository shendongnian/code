       StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader("CSV file path");
                for (int j = 0; j < xlRange.Rows.Count; j++)
                {
                    sb.Append(sr.ReadLine());
                    for (int i = 0; i < 5000; i++)
                    {
                        sb.Append(sr.ReadLine()+Environment.NewLine);
                    }
                    File.AppendAllText(j.ToString() + ".csv",sb.ToString());
                }
