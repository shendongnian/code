    public class MyViewModel
    {
        private ICommand someCommand;
        public ICommand SomeCommand
        {
            get
            {
                return someCommand 
                    ?? (someCommand = new ActionCommand(() =>
                    {
                        MessageBox.Show("SomeCommand");
                    }));
            }
        }
    }
