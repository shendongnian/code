    public interface ICore<out T>where T:Handler
    {
        T Handler {get;}
        string Text { get; }
    }
