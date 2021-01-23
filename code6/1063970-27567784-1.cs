    public sealed class ConfirmDialogViewModel : Screen
    {
        public ClosedBy CloseReason { get; private set; }
        public ConfirmDialogViewModel(string title, string message)
        {
            DisplayName = title;
            Message = message;
            CloseReason = ClosedBy.Other;
        }
        public string Message { get; set; }
        public void Ok()
        {
            CloseReason = ClosedBy.Ok;
            TryClose(true);
        }
        public void Cancel()
        {
            CloseReason = ClosedBy.Cancel;
            TryClose(false);
        }
    }
    public enum ClosedBy
    {
        Other,
        Ok,
        Cancel
    }
