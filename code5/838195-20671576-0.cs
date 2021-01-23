    var query = from input in inputs
                let split = input.Split('/')
                group split[1] by split[0] into grouping
                select new MyClass
                {
                    Category = grouping.Key,
                    SubCategory = grouping.ToList()
                };
