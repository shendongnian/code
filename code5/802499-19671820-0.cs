    public interface IOutputStream
    {
        void Open();
        void Close();
        void WriteLine(string line);
    }
    public abstract class OutputStreamBase : IOutputStream
    {
        // create cross-cutting concerns here, logging, file handling, etc.
        // create virtual methods and properties that are common to all descendants
        public virtual void Open()
        {
            throw new System.NotImplementedException();
        }
        public virtual void Close()
        {
            throw new System.NotImplementedException();
        }
        public virtual void WriteLine(string line)
        {
            throw new System.NotImplementedException();
        }
        protected virtual void DoSomething()
        {
        }
        protected abstract void DoSomethingElse();
    }
