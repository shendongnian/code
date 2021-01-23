    public interface IField
    {
            
    }
    
    public class Field<T> : IField
    {
        public string Name { get; set; }
        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }
        public int Length { get; set; }
        public T Value { get; set; }
    }
