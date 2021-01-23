          // list from DB
           var list = new List<string> { "ABC", "CDE", "EFG" };
            var selectedResult = new List<string>();
            var a = "and abc asd dsa efg";
            list.ForEach(x =>
                {
                    var result = a.ToUpperInvariant().Contains(x.ToUpperInvariant());
                    if (result)
                    {
                        selectedResult.Add(x);
                    }
                });
            var joined = selectedResult.Count > 0 ? string.Join(",", selectedResult) : "No Match";
           
