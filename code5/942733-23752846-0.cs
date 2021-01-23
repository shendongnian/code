    internal interface ICommand
    {
        // some methods...
    }
    
    public interface IProject
    {
        // some other methods...
    }
    
    internal interface IProjectWithCommands : IProject
    {
        ICommand Command { get; set; }
    }
