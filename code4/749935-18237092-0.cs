    public abstract class A
    {
        public string Data { get; set; }
        public static T Create<T>(string data) where T : A, new()
        {
            return new T() { Data = data };
        }
    }
    
    public class B : A { }
