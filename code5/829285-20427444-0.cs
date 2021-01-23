    var dict = new List<Tuple<string, string, string>>();
            using (StreamReader rdr = new StreamReader(fi1))
            {
                while (!rdr.EndOfStream)
                {
                    string ln = rdr.ReadLine();
                    string[] split_ln = ln.Split(',');
                    dict.Add(new Tuple<string, string, string>(split_ln[0], split_ln[1],null));
                }
            }
            using (StreamReader rdr = new StreamReader(fi2))
            {
                while (!rdr.EndOfStream)
                {
                    string ln = rdr.ReadLine();
                    string[] split_ln = ln.Split(',');
                    if (dict.Any(item => item.Item1 == split_ln[0]))
                    {
                        var item = dict.Find(i => i.Item1 == split_ln[0]);
                        var newtuple = new Tuple<string, string, string>(item.Item1, item.Item2, split_ln[1]);
                        dict.Remove(item);
                        dict.Add(newtuple);
                    }
                    else
                    {
                        dict.Add(new Tuple<string, string, string>(split_ln[0],null,split_ln[1]));
                    }
                }
            }
    
