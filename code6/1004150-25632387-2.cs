    [Serializable]
	public class AddressDto : ISerializable
	{
		public string Street { get; set; }
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			foreach (var property in this.GetType().GetProperties())
			{
				info.AddValue("fieldType", property.PropertyType.Name);
				info.AddValue("fieldName", property.Name);
				info.AddValue("fieldValue", property.GetValue(this, null));
			}
		}
	}
