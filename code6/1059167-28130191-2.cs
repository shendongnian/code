        ICommand _drawModelingArchitectureCommand;
        public ICommand DrawModelingArchitectureCommand
        {
            get
            {
                return _drawModelingArchitectureCommand ?? (_drawModelingArchitectureCommand = new DrawTheModelingArchitectureCommand());
            }
        }
        public class DrawTheModelingArchitectureCommand : ICommand
        {
            public bool CanExecute(object parameter)
            {
                // the code that decides whether the button will be enabled or not
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                // the code that is executed when the button is pressed
            }
        }
