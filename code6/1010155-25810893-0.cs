            var d1 = new Dictionary<double, double> { { 1.0, 1.1 } };
            var d2 = new Dictionary<double, double> { { 1.0, 1.2 } };
            var dict1 = new Dictionary<double, Dictionary<double, double>> { { 1.0, d1 } };
            var dict2 = new Dictionary<double, Dictionary<double, double>>() { { 2.0, d2 } };
            var keys = dict1.Values.SelectMany(dict => dict.Keys.ToList());
            var collection = keys.Select(key1 => new { Key = key1, Values = keys.SelectMany(key => dict1.Values.Select(k1 => k1[key]).Union(dict2.Values.Select(k1 => k1[key]))).ToList() }).ToList();            
            
            foreach (var x in collection)
            {
                Console.Write(x.Key + ": ");
                foreach (var y in x.Values)
                {
                    Console.Write(y + ",");                    
                }
            }
