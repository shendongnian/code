    using System.Runtime.Serialization;
    public static class ExceptionHelper
    {
        public static void PreserveStackTrace(this  Exception e)
        {
            var streamingContext = new StreamingContext(StreamingContextStates.CrossAppDomain);
            var objectManager = new ObjectManager(null, streamingContext);
            var serializationInfo = new SerializationInfo(e.GetType(), new FormatterConverter());
    
            e.GetObjectData(serializationInfo, streamingContext);
            objectManager.RegisterObject(e, 1, serializationInfo);
            objectManager.DoFixups(); 
        }
    }
