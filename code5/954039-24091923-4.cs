    public class DialogService : IDialogService
    {
        public bool Confirm(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButton.OKCancel) == MessageBoxResult.OK;
        }
    }
