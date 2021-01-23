    // An interface
    public interface IMySelector
    {
        bool IDontLike(string str);
    }
    // A class implementing the interface
    public class MySelector : IMySelector
    {
        public bool IDontLike(string str)
        {
            if (str.StartsWith("foo"))
            {
                return true;
            }
            return false;
        }
    }
    List<string> list = new List<string> { "foo1", "foo2", "bar1", "bar2" };
    // Using the interface
    IMySelector selector = new MySelector();
    // Begin from last, it will be faster to remove
    for (int i = list.Count - 1; i >= 0; i--)
    {
        // Your condition
        if (selector.IDontLike(list[i]))
        {
            list.RemoveAt(i);
        }
    }
