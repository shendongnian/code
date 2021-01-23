    public class MyCustomClassObject 
    {
        public Dictionary<string, object> Foo { get; set; }
		
		public MyCustomClassObject()
		{
			this.Foo = new Dictionary<string, object>();
		}
		
    }
	
	public MyCustomClassObject GetTestData()
    {
		MyCustomClassObject x = new MyCustomClassObject();
   		x.Foo.Add("PropertyA", 2);
		x.Foo.Add("PropertyC", "3");
		return x.Foo;
    }
