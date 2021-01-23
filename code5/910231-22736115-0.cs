    if (line.Contains("width"))
                        {
                                if (line.Contains("gfx"))
                                {
                                    var split = line.Split(new char[] { '=' }, 2);
                                    //var val = int.Parse(split.ToString());
                                    Console.WriteLine(split[0].ToString() + " is equal to " + split[1].ToString());
                                    npcWidth.Value = Decimal.Parse(split[1].ToString());
                                    npcWidth.Enabled = true;
                                    npcWCb.Checked = true;
                                }
                                else
                                {
                                    var split = line.Split(new char[] { '=' }, 2);
                                    Console.WriteLine(split[0].ToString() + " is equal to " + split[1].ToString());
                                    pNpcWidth.Value = Decimal.Parse(split[1].ToString());
                                    pNpcWidth.Enabled = true;
                                    pNpcWidthCb.Checked = true;
                                }
                        }
