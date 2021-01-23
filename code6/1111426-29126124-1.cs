    public interface IMyEnumerabe<T>
    {
        IEnumerator<T> GetEnumerator();
    }
    IMyEnumerabe<int> myenumerable = null;
    foreach (int el in myenumerable)
    {
        // Compiles (and in this cases crashes with a NullReferenceException :-) )
    }
