    public class MainViewModel : BindableBase,  IPartImportsSatisfiedNotification
    {
        [Import]
        public IEventAggregator eventAggregator;
        public void OnImportsSatisfied()
        {
            eventAggregator.GetEvent<AppExitEvent>().Publish("");
        }
     }
