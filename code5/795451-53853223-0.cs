    public interface IField
    {
        Type Type { get; }
        string Name { get; set; }
        int Length { get; set; }
    }
    public class Field<T> : IField
    {
        public string Name { get; set; }
        Type IField.Type => typeof(T);
        public int Length { get; set; }
        public T Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
