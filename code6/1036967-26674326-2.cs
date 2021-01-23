        public event EventHandler<SomeEventArgs> CallBackToController;
        protected virtual void OnCallBackEvent(object sender, SomeEventArgse)
        {
            EventHandler<SomeEventArgs> handle = CallBackToController;
            if (handle != null)
            {
                handle(this, e);
            }
        }
