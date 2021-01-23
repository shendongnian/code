    public class Command<T> : ICommand
    {
        public string       commandText  { get; set; }
        public Action<T>    commandFunc  { get; set; }
        public T            commandParam { get; set; }
        public void Execute()
        {
            this.commandFunc(commandParam);
        }
    }
