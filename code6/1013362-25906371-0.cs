    foreach (var line in File.ReadAllLines(@"input_5_5.txt", Encoding.GetEncoding(1250)))
            {
            int j = 1;
                    foreach (var col in line.Trim().Split(' '))
                    {
                        result[i, j] = int.Parse(col.Trim());
                        j++;
                    }
                    i++;
            }
