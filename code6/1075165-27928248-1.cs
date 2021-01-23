    public class DialogResult<T>
    {
        private readonly T _result;
        private readonly bool _canceled;
        public DialogResult(bool isCanceled)
            : this(string.Empty, isCanceled)
        {
            
        }
        public DialogResult(string result, bool canceled = false)
        {
            _result = result;
            _canceled = canceled;
        }
        public T GetResults()
        {
            if (HasDialogBeenCanceled())
                throw new InvalidOperationException("Dialog has been canceled - no results");
            return _result;
        }
        public bool HasDialogBeenCanceled()
        {
            return _canceled;
        }
    }
    // inside your dialog control
        private TaskCompletionSource<DialogResult<string>> dialogResultAwaiter;
        private Button button;
        private TextBlock textBox;
        private Popup popup;
        public async Task<DialogResult<string>> ShowPopup()
        {
            dialogResultAwaiter = new TaskCompletionSource<DialogResult<string>>();
            button.Tapped += (sender, args) => dialogResultAwaiter.SetResult(new DialogResult<string>(textBox.Text, false));
            var popup = new Popup();
            popup.Closed += PopupOnClosed;
            // popup code
            popup.IsOpen = true;
            return await dialogResultAwaiter.Task;
        }
        private void PopupOnClosed(object sender, object o)
        {
            if (dialogResultAwaiter.Task.IsCompleted)
                return;
            dialogResultAwaiter.SetResult(new DialogResult<string>(true));
        }
