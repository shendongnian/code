    public class Wibble : ISerializable
    {        
        public string Agnostic { get { return agnostic; } }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //construct a container based on my data.
            Container container = new Container(new object[]{myFoo});
            info.AddValue("RequiredReferences",container.GetFullyQualifiedReferences());
            
            byte[] containerData = Serialize(container);
            info.AddValue("TypeUnsafeData",containerData);
            //store some safe typed versions of the context data, if necessary.
            info.AddValue("SafeValues", GetSafeValues())
        }
        public Wibble(SerializationInfo info, StreamingContext context)
        { 
            var requiredAssemblies = 
               (string[])info.GetValue("RequiredReferences",typeof(string[]));
            if(AreAssembliesLoaded(requiredAssemblies )))
            {
               //deserialise the container as normal
            }
            else
            {
               //instead, load the "safe" data that we previously stored.
            }
        }
    }
