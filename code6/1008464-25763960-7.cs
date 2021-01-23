		ObservableCollectionExt o = ObservableCollectionExt.Create();
		string serialized = JsonConvert.SerializeObject(new { MyData1 = o.MyData1, MyData2 = o.MyData2, coll = o });
		var anonType = new { MyData1 = null as object, MyData2 = null as object, coll = null as object };
		dynamic d = JsonConvert.DeserializeAnonymousType(serialized, anonType);
		ObservableCollectionExt deserialized = new ObservableCollectionExt(d.MyData1, d.MyData2);
		foreach (var elem in d.coll)
			deserialized.Add((int)elem);
