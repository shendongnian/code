	[Serializable]
	public MyCalss {
		//Unity can serialise this list;
		public List<int> serializableData;
		//class contains a lot of data that cannot be serialized by Unity3D
        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            //pack all my data into the serializableData array
        }
	}
