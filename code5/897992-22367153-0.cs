    public class AnotherType 
    {
        public MyType InlinePropertyName { get; set; } 
    
        // Simple propertoes require no implimentation (above), or you can explicitly control it all (below)       
        private MyType _explicitPropertyName;
    
        public MyType ExplicitPropertyName {
           get {
                return _explicitPropertyName;
           }
    
           set {
               _explicitPropertyName = value;
           }
        }
    }
