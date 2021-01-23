    public class Property<T> where T : class
    {
        private T _value;
    
        public T Value
        {
            get 
    		{
    			return _value ?? (_value = GetInstance()); 
    		}
            set
            {
                // insert desired logic here
                _value = value;
            }
        }
    
    	private T GetInstance()
    	{
    		return (T)FormatterServices.GetUninitializedObject(typeof(T)); //does not call ctor
    	}
        public static implicit operator T(Property<T> value)
        {
            return value.Value;
        }
    
        public static implicit operator Property<T>(T value)
        {
            return new Property<T> { Value = value };
        }
    }
