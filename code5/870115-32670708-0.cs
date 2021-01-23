        static void Main(string[] args)
        {
            var o = new
            {
                ValueA = "",//Comparison Works
                ValueB = "",//Comparison Works
                ValueC = new { ValueD = "", ValueE = "" },//Comparison Works
                ValueF = new[] { new { ValueG = "", ValueH = "" } },//Fails if the array values are out of order
                ValueI = new SortedDictionary<object, object>()//Comparison works
            };
            var t = JsonConvert.DeserializeAnonymousType(
                "{\"ValueA\":1,\"ValueB\":2, \"ValueC\":{\"ValueE\":2,\"ValueD\":1}, \"ValueF\":[{\"ValueG\":10,\"ValueH\":25}],\"ValueI\":{\"Test1\":\"Val1\",\"Test2\":\"Val1\"}}", o);
            var q = JsonConvert.DeserializeAnonymousType(
                "{\"ValueB\":2,\"ValueA\":1, \"ValueC\":{\"ValueD\":1,\"ValueE\":2}, \"ValueF\":[{\"ValueH\":25,\"ValueG\":10}],\"ValueI\":{\"Test2\":\"Val1\",\"Test1\":\"Val1\"}}", o);
            var prop = t.GetType().GetProperties();
            var match = true;
            foreach (var item in prop)
            {
                var type = item.PropertyType;
                if (type.IsArray)
                {
                    var v1 = item.GetValue(t) as Array;
                    var v2 = item.GetValue(q) as Array;
                    if ((v1 != null && v2 != null))
                    {
                        if ((v1.Length != v2.Length))
                        {
                            match = false;
                            break;
                        }
                        for (int i = 0; i < v1.Length; i++)
                        {
                            if (!v1.GetValue(i).Equals(v2.GetValue(i)))
                            {
                                match = false;
                                break;
                            }
                        }
                    }
                    else if ((v1 == null && v2 != null) || (v1 != null && v2 == null))
                    {
                        match = false;
                        break;
                    }
                }
                else if (type.Name.Contains("Dictionary"))
                {
                    var v1 = (SortedDictionary<object, object>)item.GetValue(t);
                    var v2 = item.GetValue(q) as SortedDictionary<object, object>;
                    foreach (var ar in v1)
                    {
                        if (!v2.Contains(ar))
                        {
                            match = false;
                            break;
                        }
                    }
                }
                else if (!item.GetValue(t).Equals(item.GetValue(q)))
                {
                    var v1 = item.GetValue(t);
                    var v2 = item.GetValue(q);
                    match = v1.ToString().Equals(v2.ToString());
                    match = false;
                    break;
                }
            }
            if (!match)
            {
                Console.WriteLine("Objects do not match");
            }
        }
