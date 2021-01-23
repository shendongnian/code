	class classOne //In its own file (classOne.cs)
	{
		public int myInt = 5;
		public string myString = "Hello World";
		public void test()
		{
			var obj = new classTwo(this, "myInt");
			obj.test();
		}
	}
	class classTwo //In its own file (classTwo.cs)
	{
		classOne frm;
		int kind1;
		string kind2;
		string type;
		public classTwo(classOne frm, string type)
		{
			this.frm = frm;
			this.type = type;
		}
		//Doesn't work:
		public void test()
		{
			//Doesn't work:
			this.kind1 = Convert.ToInt32(this.frm.GetType().GetField(this.type).GetValue(this.frm));
			this.kind2 = Convert.ToString(this.frm.GetType().GetField("myString").GetValue(this.frm));
		}
	}
