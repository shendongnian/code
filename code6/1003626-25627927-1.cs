    public class MySimpleCommand : ICommand
    {
        public void Execute(object parameter)
        {
            // do stuff based off your tags
            string tag = parameter as string;
            if(tag == "WHATEVER_YOU_WANT")
            {
            }
            // void of the trigger libraries, lets make this simple
            // navigate to your page
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(YOUR_PAGE));
            
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
