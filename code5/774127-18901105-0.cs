    public class Program
    {
        public static void Main(string[] args)
        {
            const string json = "{\"AccruedInterest\":9.16666666666666E-6}";
            var result = JsonSerializer.DeserializeFromString<MyResult>(json);
        }
    }
    public class MyResult
    {
        public float AccruedInterest { get; set; }
    }
