    class Program
	{
		static void Main(string[] args)
		{
			Model m = new Model();
			m.SomeList1=new List<baseModel>();
			var _string = m.SomeList1.First<baseModel>().sVal;
			var _enum = m.SomeList1.First<baseModel>().eMyEnum;
		}
	}
	class baseModel {
		public string sVal;
		public myEnum eMyEnum;
        public string sVal2;
		public myEnum eMyEnum;
	}
	class Model
	{
		public List<baseModel> SomeList1 { get; set; }
		
	}
			enum myEnum{
			someVal=1,
			someVal2=2
		}
