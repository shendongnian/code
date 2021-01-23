    public sealed class DialogService : IDialogService
    {
        // ...
    
        public void ShowMessageBox(MessageBoxSettings settings)
        {
            return MessageBox.Show(/* ... */);
        }
    
        public bool? ShowOpenFileDialog(FileDialogSettings settings)
        {
            var dialog = new OpenFileDialog();
    
            // ...
    
            return dialog.ShowDialog();
        }
    
        // ...
    }
