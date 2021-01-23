    String origin = "0645063306280642002006270644062F06410639003A00200037002C003600320035002E0030003000200020000A06270644063506440627062D064A0629003A0030002E0030003000200020000A00200627064406440627062D0642002006270644062F06410639003A0030002E003000300020";
    if (origin.Count() % 2 == 0)
                {
                    List<short> list = new List<short>();
                    List<byte> bytes = new List<byte>();
                    var encode = Encoding.GetEncoding("UCS-2");
                    for (int i = 0; i < origin.Count(); i += 4)
                    {
                        list.Add(Convert.ToInt16(origin.Substring(i, 4), 16));
                    }
                    foreach (var item in list)
                    {
                        bytes.Add((byte)(item & 255));
                        bytes.Add((byte)(item >> 8));
                    }
                    return encode.GetString(bytes.ToArray());
                }
