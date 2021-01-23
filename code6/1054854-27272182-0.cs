        protected delegate void OnUIThreadDelegate();
        /// <summary>
        /// Allows the specified delegate to be performed on the UI thread.
        /// </summary>
        /// <param name="onUIThreadDelegate">The delegate to be executed on the UI thread.</param>
        protected static void OnUIThread(OnUIThreadDelegate onUIThreadDelegate)
        {
            if (onUIThreadDelegate != null)
            {
                if (Deployment.Current.Dispatcher.CheckAccess())
                {
                    onUIThreadDelegate();
                }
                else
                {
                    Deployment.Current.Dispatcher.BeginInvoke(onUIThreadDelegate);
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnUIThread(() =>
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            });
        }
