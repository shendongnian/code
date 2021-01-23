    interface IMyInt
    {
        int Value{get;set;}
    }
    
    struct MyInt : IMyInt
    {
        public int Value { get; set; }
    }
    void Main()
    {
    	var myInts = new List<IMyInt> { new MyInt{ Value = 1}, new MyInt{ Value = 2}, new MyInt{ Value = 3} };
    	var item1 = myInts[0];
    	item1.Value += 23;
    	Console.WriteLine(myInts[0].Value);
    }
