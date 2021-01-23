    var duplicates = new List<int>();
            for (int h = 0; h < a.Length; h++)
            {
                var duplicate = 0;
                for (int i = 0; i < a[h].Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (b[j] == a[h][i])
                        {
                            duplicate++;
                            break;
                        }
                    }
                }
                duplicates.Add(duplicate);
            }
