    namespace YourNamespace
    {
      public class AppRes
      {
        private static ResourceLoader load = new ResourceLoader();
        private static string GetProperty([CallerMemberName] string propertyName = null) { return propertyName; }
        public static string PropertyName { get { return load.GetString(GetProperty()); } }
      }
    }
