    [DataContract]
    	[KnownType(typeof(int[]))]
        [KnownType(typeof(bool[]))]
    	public class CompositeType
    	{
    		[DataMember]
    		public object UsedForKnownTypeSerializationObject;
		[DataMember]
		public string StringValue
		{
			get;
			set;
		}
		[DataMember]
		public Dictionary<string, object> Parameters
		{
			get;
			set;
		}
	}
