    enum ErrorMessage {
        OutOfMemory,
        PEBCAK,
        IdTenTError,
        // etc...
    }
    public static class ResourceHelper {
         public static String GetMessage(ErrorMessage message) {
              String key = "ErrorMessage_" + message.ToString();
              return ResourceManager.GetString( key );
         }
    }
