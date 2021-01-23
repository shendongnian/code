    class a {
      public string name {get; set;}
    }
    
    class b {
      public b() {
        PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(a))["name"];
     }
