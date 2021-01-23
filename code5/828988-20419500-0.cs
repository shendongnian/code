    public interface ISerializer
    {
        void Write(BinaryWriter output, object value);
    }
    public interface ISerializer<TValue> : ISerializer
    {
        void Write(BinaryWriter output, TValue value);
    }
    public class BooleanSerializer : ISerializer<bool>
    {
        public void Write( BinaryWriter output, bool value )
        {
            output.Write( value );
        }
    
        // explicit interface implementation so that it does not show up in IntelliSense 
        // when you use the class itself (instead of ISerializer).
        ISerializer.Write(BinaryWriter output, object value)
        {
            if (!(value is bool))
                 throw new ArgumentOutOfRangeException();
            this.Write(output, (bool)value);
        }
    }
