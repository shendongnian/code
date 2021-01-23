    public abstract class BaseClass<T>
    {
        public List<T> SomeList { get; set; }
    }
    public class ChildClass<T> : BaseClass<T>
    {
    }
    public void IterateOverChild<T>(BaseClass<T> someChildClass)
    {
        foreach (var element in someChildClass.SomeList)
        {
            Console.WriteLine(element);
        }
    }
