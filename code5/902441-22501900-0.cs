    public abstract class ContentBase<T>
    {
        public static Func<string> TypeLocator { get; set; }
        static ContentBase()
        {
            TypeLocator = () => typeof(T).Name;
        }
        
    }
    public class Content1 : ContentBase<Content1>    {
        private static string Content1Type = "The type of Content 1";
        static Content1()
        {
            TypeLocator = () => Content1Type;
        }
    }
    public class Content2 : ContentBase<Content2>    {}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content1.Type => " + GetObject<Content1>()); // Content1
            Console.WriteLine("Content2.Type => " + GetObject<Content2>()); // Content2
        }
        private static string GetObject<TContent>() where TContent: ContentBase<TContent>
        {
            var typeLocator = typeof(ContentBase<TContent>).GetProperties()[0].GetValue(null, null) as Func<string>;
            return typeLocator.Invoke();
        }
    }
