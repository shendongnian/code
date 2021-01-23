    public class MyDictionary<T> : Dictionary<T, List<T>>
        {
            
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var test = new MyDictionary<int>();
            }
        }
