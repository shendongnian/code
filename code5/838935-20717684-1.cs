		List<String> list = new List<String>();
		for(int i = 0; i < items.Count; i++)
		{
			int x = items[i].Day;
			string a = x.ToString();
			string b = items[i].Time;
			string c = items[i].Title;
			//here whatever format you want..
			list.Add(a + " " + b + " " + c));
		}
