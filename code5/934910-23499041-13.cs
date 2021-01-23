    public class CommandB : ICommand
    {
        public bool CanGetArgumentsFrom(string input)
        {
            return input.Contains("argB") && input.Contains("argC");
        }
        public void Execute()
        {
            /* execute command B */
        }
    }
