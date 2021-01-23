    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class MarkerAttribute : Attribute {
      public string UrlAction { get; private set; }
      public MarkerAttribute(string urlAction) {
        if (string.IsNullOrEmpty(urlAction)) {
          throw new ArgumentNullException("urlAction");
        }
        UrlAction = urlAction;
      }
    }
