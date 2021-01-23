    public class C {
		[Key, Column(Order = 0)]
		public int AID { get; set; }
		[ForeignKey("AID")]
		public virtual A A { get; set; }
		[Key, Column(Order = 1)]
		public int BID { get; set; }
		[ForeignKey("BID")]
		public virtual B B { get; set; }
		public string OtherProperty { get; set; }
	}
