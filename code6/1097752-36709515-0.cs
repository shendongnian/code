    using System;
    using UIKit;
    using System.Threading.Tasks;
    
    namespace Sample
    {
	
	public partial class ViewController : UIViewController
	{
		
		public ViewController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			this.InvokingMethod ();
		
		}
		public static Task<bool> ShowOKCancel (UIViewController parent, string strTitle, string strMsg)
		{
			// method to show an OK/Cancel dialog box and return true for OK, or false for cancel
			var taskCompletionSource = new TaskCompletionSource<bool> ();
			var alert = UIAlertController.Create (strTitle, strMsg, UIAlertControllerStyle.ActionSheet);
			// set up button event handlers
			alert.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, a => taskCompletionSource.SetResult (true)));
			alert.AddAction (UIAlertAction.Create ("Cancel", UIAlertActionStyle.Default, a => taskCompletionSource.SetResult (false)));
			// show it
			parent.PresentViewController (alert, true, null);
			return taskCompletionSource.Task;
		}
		private async void InvokingMethod ()
		{
			var userClickedOk = await ShowOKCancel (this, "Action Sheet Title", " It is just awesome!");
			// go on to use the result in some way		
			if (userClickedOk) {
				Console.WriteLine ("Clicked on Okay");
			} else {				
				Console.WriteLine ("Clicked on Cancel");
			};
		}
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
    }
