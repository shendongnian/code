    public class TestController : UITableViewController
    {
        private UIButton sendButton;
        ...
        public override void LoadView()
        {
            base.LoadView();
            if (sendButton == null)
            {
                sendButton = new UIButton (UIButtonType.RoundedRect)
                {
                     Frame = new RectangleF (100, 100, 80, 50),
                     BackgroundColor = UIColor.Blue
                };
                View.AddSubview(sendButton);
            }
        }
    
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            sendButton.TouchUpInside += HandleTouchUpInside;
        }
        public override void ViewDidUnload()
        {
            if (sendButton != null)
            {
                sendButton.Dispose();
                sendButton = null;
            }
        }
    }
