	public class ReplacementType {
		[DataMember(Name = "Serialized")]
		public object Serialized { get; set; }
		[DataMember(Name = "OriginalType")]
		public string OriginalTypeFullName { get; set; }
	}
