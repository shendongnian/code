        public MyViewModel()
        {
    .
    .
    .
        public void Register(Inject dependencies)
        {
            try
            {
                this.Injected = dependencies;
                this.Injected.RefreshConfirmation.RequestConfirmation += (message, caption) =>
                    {
                        var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                        return result;
                    };
                this.Injected.ExtendTimelineConfirmation.RequestConfirmation += (message, caption) =>
                    {
                        var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                        return result;
                    };
    .
    .
    .
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
