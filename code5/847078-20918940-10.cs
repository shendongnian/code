    using System.Runtime.Serialization;
    ...
    [DataContract]
	public class MyTable
	{
		[DataMember(Name = "tableID")]
		public string table_id { get; set; }
		[DataMember(Name = "size")]
		public int table_size { get; set; }
		[DataMember(Name = "zone")]
		public string table_zone { get; set; }
		
		[DataMember(Name = "area")]
		public string table_area { get; set; }
	}
