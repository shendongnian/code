    [Serializable]
    public class Widget : ISerializable
    {
      public Widget( SerializationInfo serializationInfo , StreamingContext context )
      {
        // your rehydration logic here
      }
      public void GetObjectData( SerializationInfo info , StreamingContext context )
      {
        // your dehydration logic here
      }
      ...
    }
