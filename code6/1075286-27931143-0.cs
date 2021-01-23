    public class MyType
    {
        // Your own implementation
        // Properties
        // And methods
    
        public static MyType Create(TheirEntity entity)
        {
            // Create an instance of your type from their object
        }
        // Or provide a conversion operator, it could be implicit if you'd like
        public static explicit MyType(TheirEntity entity)
        {
             // Implement a conversion here
        }
    }
