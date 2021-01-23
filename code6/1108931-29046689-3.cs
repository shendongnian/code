    public class MySelector : IEquatable<string>
    {
        public bool Equals(string str)
        {
            // Strange concept of equality... All the 
            // words that start with foo are equal :-)
            if (str.StartsWith("foo"))
            {
                return true;
            }
            return false;
        }
    }
    List<string> list = new List<string> { "foo1", "foo2", "bar1", "bar2" };
    // Using the interface
    IEquatable<string> selector = new MySelector();
    // Begin from last, it will be faster to remove
    for (int i = list.Count - 1; i >= 0; i--)
    {
        // Your condition
        if (selector.Equals(list[i]))
        {
            list.RemoveAt(i);
        }
    }
