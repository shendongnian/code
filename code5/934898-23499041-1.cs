    public class CommandA : ICommand
    {
        public bool CanGetArgumentsFrom(string input)
        {
            return input.Contains("argA");
        }
        public void Execute()
        {
            /* execute command A */
        }
    }
