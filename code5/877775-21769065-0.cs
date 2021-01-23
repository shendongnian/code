    public partial class myViewController : UIViewController
    {
        UITapGestureRecognizer _tap;
        NSObject _shownotification;
        NSObject _hidenotification;
        public myViewController() : base("myViewController", null)
        {
            // This code dismisses the keyboard when the user touches anywhere
            // outside the keyboard.
            _tap = new UITapGestureRecognizer();
            _tap.AddTarget(() =>{
                View.EndEditing(true);
            });
            _tap.CancelsTouchesInView = false;
            View.AddGestureRecognizer(_tap);
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            // Register our callbacks
            _hidenotification = UIKeyboard.Notifications.ObserveDidHide(HideCallback);
            _shownotification = UIKeyboard.Notifications.ObserveWillShow(ShowCallback);
        }
        public override void ViewWillDisappear(bool animated)
        {
            // Unregister the callbacks
            if (_shownotification != null)
                _shownotification.Dispose();
            if (_hidenotification != null)
                _hidenotification.Dispose();
            base.ViewWillDisappear(animated);
        }
        void ShowCallback (object sender, MonoTouch.UIKit.UIKeyboardEventArgs args)
        {
            // This happens if the user focuses a textfield outside of the
            // tableview when the tableview is empty.
            UIView activeView = this.View.FindFirstResponder();
            if ((activeView == null) || (activeView == Customer))
                return;
            // Get the size of the keyboard
            RectangleF keyboardBounds = args.FrameEnd;
            // Create an inset and assign it to the tableview
            UIEdgeInsets contentInsets = new UIEdgeInsets(0.0f, 0.0f, keyboardBounds.Size.Height, 0.0f);
            myTableView.ContentInset = contentInsets;
            myTableView.ScrollIndicatorInsets = contentInsets;
            // Make sure the tapped location is visible.
            myTableView.ScrollRectToVisible(activeView.Frame, true);
        }
        void HideCallback (object sender, MonoTouch.UIKit.UIKeyboardEventArgs args)
        {
            // If the tableView's ContentInset is "zero", we don't need to
            // readjust the size
            if (myTableView.ContentInset.Top == UIEdgeInsets.Zero.Top)
                return;
            // Remove the inset when the keyboard is hidden so that the
            // TableView will use the whole screen again.
            UIView.BeginAnimations (""); {
                UIView.SetAnimationCurve (args.AnimationCurve);
                UIView.SetAnimationDuration (args.AnimationDuration);
                var viewFrame = View.Frame;
                var endRelative = View.ConvertRectFromView (args.FrameEnd, null);
                viewFrame.Height = endRelative.Y;
                View.Frame = viewFrame;
                myTableView.ContentInset = UIEdgeInsets.Zero;
                myTableView.ScrollIndicatorInsets = UIEdgeInsets.Zero;
            } UIView.CommitAnimations ();
        }
    }
