    for (int i = 0; i < names.Length - 1; i++)
            {
                string temp = string.Empty;
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (names[i][0] > names[j][0])
                    {
                        temp = names[i].ToString();
                        names[i] = names[j].ToString();
                        names[j] = temp;
                    }
                }
            }
            for (int i = 0; i < names.Length - 1; i++)
            {
                int l = 0;
                if (names[i][0] == names[i + 1][0])
                {
                    string temp = string.Empty;
                    if (names[i].Length > names[i + 1].Length)
                        l = names[i + 1].Length;
                    else
                        l = names[i].Length;
                    for (int j = 0; j < l; j++)
                    {
                        if (names[i][j] != names[i + 1][j])
                        {
                            if (names[i][j] > names[i + 1][j])
                            {
                                temp = names[i].ToString();
                                names[i] = names[i + 1].ToString();
                                names[i + 1] = temp;
                            }
                            break;
                        }
                    }
                }
            }
            foreach (var item in names)
            {
                Console.WriteLine(item.ToString());
            }
