                    string sRead = sr.ReadLine();
                    char[] srcTemp = sRead.ToCharArray();
                    for (int i = 0; i < srcTemp.Length - 1; i++)
                    {
                        if ((int)srcTemp[i] == 34)
                        {
                            int yCharnichart = 0;
                            for (int c = i + 1; c < srcTemp.Length - 1; c++)
                            {
                                if ((int)srcTemp[c] == 34) break;
                                if ((int)srcTemp[c] == 44) srcTemp[c] = (char)182;
                                yCharnichart++;
                            }
                            i += yCharnichart + 1;
                        }
                    }
                    StringBuilder sb = new StringBuilder();
                    sb.Append(srcTemp);
