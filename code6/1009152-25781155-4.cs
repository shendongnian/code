    public class DialogViewmodel : INPCBase, IDialogResultVMHelper
    {
        private readonly Lazy<DelegateCommand> _acceptCommand;
        public DialogViewmodel()
        {
            this._acceptCommand = new Lazy<DelegateCommand>(() => new DelegateCommand(() => InvokeRequestCloseDialog(new RequestCloseDialogEventArgs(true)), () => **Your Condition goes here**));
        }
        public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
        private void InvokeRequestCloseDialog(RequestCloseDialogEventArgs e)
        {
            var handler = RequestCloseDialog;
            if (handler != null) 
                handler(this, e);
        }
    }
