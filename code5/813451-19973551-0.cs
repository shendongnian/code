    public static class Ext
        {
            public static void Serialize(this Guid guid_, StringWriter sw_)
            {
                sw_.Write(guid_.ToString("B"));
            }
    
            public static void Serialize(this int id, StringWriter sw_)
            {
                sw_.Write(id.ToString());
            }
    
    
        }
    
        public class Field<T>
        {
            public T value;
    
            public void Serialize(StringWriter sw_)
            {
                Delegate.CreateDelegate(typeof(Action<T, StringWriter>), typeof(Ext), "Serialize").DynamicInvoke(value, sw_);
            }
    
        }
