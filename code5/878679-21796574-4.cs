    public class UsingBase : IDisposable
    {
        protected Action end;
        public UsingBase(Action start, Action end) { this.end = end; if (start != null) start(); }
        public void Dispose() { if (end != null) end(); }
        public void Cancel() { end = null; }
    }
    
    class HideCursor : UsingBase { public HideCursor() : base(() => Console.CursorVisible = false, () => Console.CursorVisible = true) { } }
    
    public static void DisplayTitle(...)
    {
        ...
        using (new HideCursor())
        {
           //Display the title
        }
        ...
    }
