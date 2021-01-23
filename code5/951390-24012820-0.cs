             List<List<string>> ls=new List<List<string>>();
             ls.Add(new List<string>(){"Hello"});
             ls.Add(new List<string>(){"Hello"});
             ls.Add(new List<string>() { "He" });
             IEnumerable<IEnumerable<string>> tableData = ls;
             var abc = tableData.SelectMany(p => p).Distinct();
