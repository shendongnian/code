	void Main()
	{
		var dic = new Dictionary<int,string>();
        // Instead of having a method to check, we use this Action
		Action<int> tryDic = (i) => {
			if (dic.ContainsKey(i))
				Console.WriteLine("{0}:{1}", i, dic[i]);
			else
				Console.WriteLine("dic has no key {0}", i);
		};
		
		dic.Add(1,"one");
		dic.Add(2,"two");
		
		// dic.Keys   = 1, 2
		// dic.Values = one, two
		
		tryDic(1); // one
		tryDic(3); // dic has no key 3 (Happens in Action above)
		
		dic[1]="wow";
		tryDic(1); // wow
		
	}
