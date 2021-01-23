    public class ChatViewModel
    {
        public string ChatName { get; set; }
    
        private ICommand chatCommand;
        public ICommand ChatCommand
        {
            get
            {
                return chatCommand
                    ?? (chatCommand = new SimpleCommand() {
                        CanExecutePredicate = o => true,
                        ExecuteAction = o => MessageBox.Show("Hurray :-D")
                    });
            }
        }
    }
