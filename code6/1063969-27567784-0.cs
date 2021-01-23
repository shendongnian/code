    public sealed class ConfirmDialogViewModel : Screen
    {
        public ConfirmDialogViewModel(string title, string message)
        {
            DisplayName = title;
            Message = message;
        }
        public string Message { get; set; }
        public void Ok()
        {
            TryClose(true);
        }
        public void Cancel()
        {
            TryClose(false);
        }
    }
