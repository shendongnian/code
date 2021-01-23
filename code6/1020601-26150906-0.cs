	void Main()
	{
		var dic = new Dictionary<int,string>();
		Action<int> tryDic = (i) => {
			if (dic.ContainsKey(i))
				Console.WriteLine("{0}:{1}", i, dic[i]);
			else
				Console.WriteLine("dic has no key {0}", i);
		};
		
		dic.Add(1,"one");
		dic.Add(2,"two");
		
		dic.Keys.Dump("Keys"); // 1,2
		dic.Values.Dump("values"); // one, two
		
		tryDic(1); // one
		tryDic(3); // dic has no key 3
		
		dic[1]="wow";
		tryDic(1); // wow
		
	}
