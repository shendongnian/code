    public class MyController: UIViewController
    {
        readonly ISomeService service;
        public MyController(IntPtr handle) : base(handle)
        {
            service = AppDelegate.IsInDesignerView ?
                new Moq<ISomeService>() :
                MyIoCContainer.Get<ISomeService>();
        }
    }
