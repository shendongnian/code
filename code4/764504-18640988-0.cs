    public class ApplicationShell
    {
        public ApplicationShell() 
        {
            // Load plugins
            ....
            // Discover commands
            var commandProvider = SomePlugin as IProvideCommands;
           
            if(commandProvider != null)
            {
                DoStuffWith(commandProvider.Commands);
            }
        }
    }
