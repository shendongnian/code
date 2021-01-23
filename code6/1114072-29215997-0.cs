        public class ViewModel : ViewModelBase
        {
            public ViewModel()
            {
                CloseComand = new DelegateCommand((obj) =>
                    {
                        MessageBus.Instance.Publish(Messages.REQUEST_DEPLOYMENT_SETTINGS_CLOSED, null);
                    });
            }
    }
