    [KnownType(typeof(AddressDto))]
	[KnownType(typeof(List<MetadataObject>))]
	[Serializable]
	public class UserInfoDto : ISerializable
	{
		public string UserName { get; set; }
		public int Age { get; set; }
		public AddressDto Address { get; set; }
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			var nodes = this.GetType().GetProperties().Select(property =>
			{
				return new MetadataObject
				{
					FieldType = property.PropertyType.Name,
					FieldName = property.Name,
					FieldValue = property.GetValue(this, null)
				};
			}).ToList();
			info.AddValue("fieldType", this.GetType().Name);
			info.AddValue("objectValue", nodes);
		}
	}
