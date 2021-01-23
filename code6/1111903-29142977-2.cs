    struct MyData
	{
		public int SetID { get; set; }
		public int ID { get; set; }
		public string Value { get; set; }
		public override string ToString()
		{
			return string.Format("SetID={0}, ID={1}, Value={2}", SetID, ID, Value);
		}
	}
