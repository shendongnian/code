    /// <summary>
    /// DialogViewModel class which should be inherited for all view 
    /// model that want to be displayed as metro dialogs.
    /// </summary>
    public abstract class DialogViewModel : Screen, IDialogViewModel
    {
        private readonly TaskCompletionSource<int> tcs;
        internal Task Task { get { return tcs.Task; } }
        /// <summary>
        /// Deafult constructor.
        /// </summary>
        protected DialogViewModel()
        {
            tcs = new TaskCompletionSource<int>();
        }
        /// <summary>
        /// Close the dialog.
        /// </summary>
        protected void Close()
        {
            tcs.SetResult(0);
            var handler = Closed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        /// <summary>
        /// Closed event.
        /// </summary>
        public event EventHandler Closed;
    }
    /// <summary>
    /// DialogViewModel class which should be inherited for all view 
    /// model that want to be displayed as metro dialogs that can return a 
    /// specific result.
    /// </summary>
    public abstract class DialogViewModel<TResult> : Screen, IDialogViewModel
    {
        private readonly TaskCompletionSource<TResult> tcs;
        internal Task<TResult> Task { get { return tcs.Task; } }
        /// <summary>
        /// Deafult constructor.
        /// </summary>
        protected DialogViewModel()
        {
            tcs = new TaskCompletionSource<TResult>();
        }
        /// <summary>
        /// Close the dialog.
        /// </summary>
        protected void Close(TResult result)
        {
            tcs.SetResult(result);
            var handler = Closed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        /// <summary>
        /// Closed event.
        /// </summary>
        public event EventHandler Closed;
    }
    
