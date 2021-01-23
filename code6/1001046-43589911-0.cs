    public class MyViewController : UIViewController
    {
    	public override void ViewDidAppear(bool animated)
    	{
    		base.ViewDidAppear (animated);
    		MyButton.TouchUpInside =+ DoSomething;
    	}
	    void DoSomething (object sender, EventArgs e) { ... }
    }
