        public static void DoStuff(string fieldName)
    	{
			List<test> ban = new List<test>();
			ban.Add(new test() { number = 40, notNumber = "hi" });
			ban.Add(new test() { number = 30, notNumber = "bye" });
			var result = ban.Select(item => item.GetType().GetField(fieldName).GetValue(item));
			foreach (var item in result)
			{
				Console.WriteLine(item);
			}
		}
		class test
		{
			public int number;
			public string notNumber;
		}
