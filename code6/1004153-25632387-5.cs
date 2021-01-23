    [DataContract]
	public class MetadataObject
	{
		[DataMember(Name = "fieldType")]
		public string FieldType { get; set; }
		[DataMember(Name = "fieldName")]
		public string FieldName { get; set; }
		[DataMember(Name = "fieldValue")]
		public object FieldValue { get; set; }
	}
