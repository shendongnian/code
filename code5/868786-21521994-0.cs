    [DataContract]
	public class Info
	{
		[DataMember]
		public Content Content { get; set; }
		[DataMember]
		public string Status { get; set; }
	}
	public class Content
	{
		[DataMember]
		public string API { get; set; }
		[DataMember]
		public string DisplayVersion { get; set; }
		[DataMember]
		public int Version { get; set; }
	}
