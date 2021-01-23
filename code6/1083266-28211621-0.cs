    public class Command : ICommand
    {
        public string commandText { get; set; }
        public Action commandFunc { get; set; }
        public void Execute()
        {
            this.commandFunc();
        }
    }
