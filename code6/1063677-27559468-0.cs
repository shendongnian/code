     List<string> selected=new List<string>();
     var result = str.Split(';').Select(s =>
                                           {
                                             var word = s.Replace("/n", "");
                                             if (selected.Contains(word))
                                             {
                                               return s.Replace(word,"")+"-";
                                             }
                                             else
                                             {
                                               selected.Add(word);
                                               return s;
                                             }
                                            }).Aggregate<string, string>(null, (current, item) => current + item);
