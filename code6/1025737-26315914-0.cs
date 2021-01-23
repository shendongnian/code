     string[] array = new string[]{
                                            "name:john",
                                            "job:engineer",
                                            "description:engineering is blah blah blah blah blah bla"};
           
            List<Tuple<string, string>> mylist = new List<Tuple<string, string>>();
                         
           var objNotNaturalPattern = new Regex("\\s*(?<Key>.+)\\s*:(?<Value>.*)",
                                               RegexOptions.IgnoreCase);
            foreach(var arrayvalue in array)
            {
                var m = objNotNaturalPattern.Match(arrayvalue);
                if (m.Success)
                {
                    string key = m.Groups["Key"].Value.Trim();
                    string value = m.Groups["Value"].Value.Trim();
                    mylist.Add(new Tuple<string, string>(key,value));
                }
            }
