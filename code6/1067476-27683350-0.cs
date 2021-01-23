    public static class ReadOnly
    {
        public static ReadOnly<T> Create<T>(T val) where T : struct
        {
            return new ReadOnly<T>(val);
        }
    }
    
    public class ReadOnly<T> where T : struct
    {
        private readonly T _value;
        
        public ReadOnly(T val)
        {
            this._value = val;
        }
        
        public T Value { get { return this._value; } }
    }
    
    public String calculateValue(int index_param) {
        //a highly complicated transactional method which returns a String
        var read_only_index_param = ReadOnly.Create(index_param);
        Console.WriteLine(read_only_index_param.Value);
    }
