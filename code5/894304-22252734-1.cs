    void Main()
    {
        var a = new Dummy();
        foreach (var x in a)
        {
            int y = x;
        }
    }
    
    public class Dummy : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return 10;
        }
    }
