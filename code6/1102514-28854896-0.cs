    public abstract class Base
    {
        protected static void InitializeTaggedFields(Type aType)
        {
            // aType will be of the instantiated type:
            // When a "StoreThis" is instantiated,
            // aType.Equals(typeof(StoreThis)) is true,
            // if a "StoreThat" was instatiated
            // aType.Equals(typeof(StoreThat)) is true.
            // etc, etc.
        }
     
        public Base()
        {
            InitializeTaggedFields(this.GetType());
        }
    }
    
    // User defined custom class inheriting my Base class
    public class StoreThis : Base
    {
        public StoreThis()
        {
        }
    }
    public class StoreThat : Base
    {
        public StoreThat()
        {
        }
    }
