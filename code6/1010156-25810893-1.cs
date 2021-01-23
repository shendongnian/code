            var d1 = new Dictionary<double, double> { { 1.0, 1.1 } };
            var d2 = new Dictionary<double, double> { { 1.0, 1.2 } };
            var d3 = new Dictionary<double, double> { { 1.1, 1.3 } };
            var d4 = new Dictionary<double, double> { { 1.1, 1.4 } };
            var dict1 = new Dictionary<double, Dictionary<double, double>> { { 1.0, d1 }, { 2.0, d3 } };
            var dict2 = new Dictionary<double, Dictionary<double, double>>() { { 3.0, d2 }, { 4.0, d4 } };
            var keys = dict1.Values.SelectMany(dict => dict.Keys.ToList());
            var collection = keys.Select(key1 => new
            {
                Key = key1,
                Values = keys.SelectMany(key =>
                    dict1.Values.Where(k1 => k1.ContainsKey(key1)).Select(k1 => k1[key1]).Union(
                    dict2.Values.Where(k2 => k2.ContainsKey(key1)).Select(k2 => k2[key1]))
                    ).Distinct().ToList()
            }).ToList();
            foreach (var x in collection)
            {
                Console.Write(x.Key + ": ");
                foreach (var y in x.Values)
                {
                    Console.Write(y + ",");
                }
                Console.WriteLine();
            }
