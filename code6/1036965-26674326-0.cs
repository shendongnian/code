        public event EventHandler<SomeEventArgs> CallBackToWindow;
        protected virtual void OnCallBackEvent(object sender, SomeEventArgse)
        {
            EventHandler<SomeEventArgs> handle = CallBackToWindow;
            if (handle != null)
            {
                handle(this, e);
            }
        }
