    public interface IMyEnumerabe<T>
    {
        IEnumerator<T> GetEnumerator();
    }
    IMyEnumerabe<int> myenumerable = null;
    foreach (var el in myenumerable)
    {
        // Compiles (and in this cases crashes with a NullReferenceException :-) )
    }
