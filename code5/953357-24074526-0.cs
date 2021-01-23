	class Type1
	{
		public int Key1 { get; set; }
		public int Key2 { get; set; }
		public string Type1Prop { get; set; }
		public Type1(int key1, int key2, string prop)
		{
			Key1 = key1;
			Key2 = key2;
			Type1Prop = prop;
		}
	}
	class Type2
	{
		public int Key1 { get; set; }
		public int Key2 { get; set; }
		public string Type2Prop { get; set; }
		public Type2(int key1, int key2, string prop)
		{
			Key1 = key1;
			Key2 = key2;
			Type2Prop = prop;
		}
	}
	public void Main()
	{	
		var list1 = new List<Type1>
		{
			new Type1(1,1,"Value"), new Type1(1,2,"Value"), new Type1(2,1,"Value"), new Type1(2,2,"Value")
		};
		var list2 = new List<Type2>
		{
			new Type2(1,1,"Value"), new Type2(2,1,"Value"), new Type2(3,1,"Value")
		};
		var in1ButNot2 = list1.Where(item => !list2.Any(item2 => item2.Key1 == item.Key1 && item2.Key2 == item.Key2)).ToList();
		var in2ButNot1 = list2.Where(item => !list1.Any(item2 => item2.Key1 == item.Key1 && item2.Key2 == item.Key2)).ToList();
		var in1And2 = list2.Where(item => list1.Any(item2 => item2.Key1 == item.Key1 && item2.Key2 == item.Key2)).ToList();
		in1ButNot2.ForEach(item => Console.WriteLine("in1ButNot2 - Key1={0},Key2={1}", item.Key1, item.Key2));
		in2ButNot1.ForEach(item => Console.WriteLine("in2ButNot1 - Key1={0},Key2={1}", item.Key1, item.Key2));
		in1And2.ForEach(item => Console.WriteLine("in1And2 - Key1={0},Key2={1}", item.Key1, item.Key2));
	}
