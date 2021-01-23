	public class Address : Int32Entity {
		public string Street { get; set; }
		public string City { get; set; }
		public int Zip { get; set; }
		public string Building { get; set; }
		public string Unit { get; set; }
		public UnitType? UnitType { get; set; }
		public string CrossStreets { get; set; }
		public int? GateCode { get; set; }
		public AddressType Type { get; set; }
		public DbGeography Position { get; set; }
		#region Relationship Properties
		public byte StateId { get; set; }
		public virtual State State { get; set; }
		#endregion
	}
