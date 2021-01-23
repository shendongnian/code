    public class ViewModel 
    {
        private void MyCommandExecuted(object parameter)
        {
            if (this.confirmation.Confirm("Please confirm", "Are you sure you want to ...?")
            {
                ...
            }
        }
