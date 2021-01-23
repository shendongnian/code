            IEnumerable<string> keys = new List<string>() { "A", "B", "C", "A", "B", "C", "D" };
            IEnumerable<string> values = new List<string>() { "Val A", "Val B", "Val C", "Val A", "Val B", "Val C", "Val D" };
            var x = from string key in keys
                    join string val in values on key equals val.Substring(val.Length - 1, 1)
                    select new
                    {
                        key,
                        val
                    };
