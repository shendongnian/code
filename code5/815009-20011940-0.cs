    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyNamedObject.Instance.Name);
        }
    }
    public abstract class NamedObject<T> where T : NamedObject<T>, new()
    {
        private static T _instance;
        public abstract string Name { get; }
        public static T Instance
        {
            get { return _instance ?? (_instance = new T()); }
        }
    }
    public class MyNamedObject : NamedObject<MyNamedObject>
    {
        public override string Name
        {
            get { return "My Named Object Name"; }
        }
    }
