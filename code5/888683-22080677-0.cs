                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line) && line.Trim() == "[HRData]")
                    {
                        break;
                    }
                }
    
                while (!sr.EndOfStream)
                {
                    string split = sr.ReadLine();
                    string[] values = split.Split('\t');
    
                    foreach (String value in values)
                    {
                        hrdata[i, j] = int.Parse(value);
                        i++;
                        if (i > 5)
                        {
                            i = 0;
                            j++;
                        }
                    }
                }
