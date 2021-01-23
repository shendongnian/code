    public class YourViewModel: Conductor<IScreen>.Collection.OneActive, IHandle<OpenNewBrowser>
    {
        // ...
        public void Handle(OpenNewBrowser myEvent)
        {
            // Create your new ViewModel instance here, or obtain existing instance.
            // ActivateItem(instance)
        }
    }
