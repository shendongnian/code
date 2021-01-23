    [Register ("MyController")]
    class MyController : UIViewController, IComponent
    {
        #region IComponent implementation
        public ISite Site { get; set; }
        public event EventHandler Disposed;
        #endregion
        readonly ISomeService service;
    
        public MyController(IntPtr handle) : base(handle)
        {
        }
        public override void AwakeFromNib ()
        {
            if (Site == null || !Site.DesignMode)
                service = MyIoCContainer.Get<ISomeService>();
        }
    }
