    internal interface ICommand
    {
        // some methods...
    }
    public abstract class Project
    {
        // some other methods...
        internal ICommand Command { get; set; }
    }
