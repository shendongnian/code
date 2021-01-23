    public class ViewModel
    {
        public ObservableCollection<Command> Commands { get; private  set; }
        public ViewModel()
        {
            Commands = new ObservableCollection<Command>();
        }
        // You will add commands at some point at runtime.
        public void AddSomeCommands()
        {
            Commands.Add(new Command("Command1", () => MessageBox.Show("This is Command1!")));
            Commands.Add(new Command("Command2", () => MessageBox.Show("This is Command2!!")));
            Commands.Add(new Command("Command3", () => MessageBox.Show("This is Command3!!!")));
            Commands.Add(new Command("Command4", () => MessageBox.Show("This is Command4!!!!")));
        }
    }
