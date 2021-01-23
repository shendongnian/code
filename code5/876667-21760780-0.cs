    class PointPresenter : INotifyPropertyChanged
    {
        private IDataService DAL { get; set; }
        protected Control EventInvoker { get; private set; }
        public PointPresenter()
        {
            // get your DAL reference however you'd like
            DAL = RootWorkItem.Services.Get<IDataService>();
            EventInvoker = new Control();
            // this is required to force the EE to actually create the 
            // control's Window handle
            var h = EventInvoker.Handle;
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            try
            {
                if (m_disposed) return;
                EventInvoker.BeginInvokeIfRequired(t =>
                {
                    try
                    {
                        PropertyChanged.Fire(this, propertyName);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                });
            }
            catch (ObjectDisposedException)
            {
                // if the Form to which we're sending a message is disposed, 
                // this gets thrown but can safely be ignored
            }
            catch (Exception ex)
            {
                // TODO: log this
            }
        }
        public int MyDataValue
        {
            get { return DAL.Data; }
            set
            {
                if (value == MyDataValue) return;
                DAL.Data = value;
                RaisePropertyChanged("MyDataValue");
            }
        }
    }
