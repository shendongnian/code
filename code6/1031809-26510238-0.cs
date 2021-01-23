            var dict1 = new Dictionary<string, string>();
            var dict2 = new Dictionary<string, string>();
            for (var x = 0; x < 1000000; x++)
            {
                dict1.Add(x.ToString(), x.ToString());
            }
            for (var x = 0; x < 2000000; x+=2)
            {
                dict2.Add(x.ToString(), x.ToString());
            }
            var hs1 = new HashSet<string>(dict1.Values);
            var hs2 = new HashSet<string>(dict2.Values);
            hs1.IntersectWith(hs2);
