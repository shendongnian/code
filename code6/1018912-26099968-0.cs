	var a = new List<Tuple<string,int>>();
	a.Add(new Tuple<string,int>("john",80));
	a.Add(new Tuple<string,int>("mike",75));
	a.Add(new Tuple<string,int>("james",70));
	a.Add(new Tuple<string,int>("ashley",70 ));
	a.Add(new Tuple<string,int>("kate",60  ));
	a.Where(x=>x.Item2>=a.OrderBy(i=>i.Item2).Skip(2).Take(1).SingleOrDefault ().Item2).Dump();
