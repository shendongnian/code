    public override void ViewDidLoad ()
    {
    	base.ViewDidLoad ();
    			
    	// Perform any additional setup after loading the view, typically from a nib.
    	this.btnTest.TouchUpInside += HandleTouchUpInside;
    }
    
    UIDatePicker picker;
    
    void HandleTouchUpInside (object sender, EventArgs e)
    {
    	var d = UIAlertController.Create( "Confirm", "Fill below with the required info.", UIAlertControllerStyle.Alert);
    
    	d.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, ((UIAlertAction obj) => {})));
    	d.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
    
    	d.AddTextField((delegate(UITextField obj) {
    		picker = new UIDatePicker ();
    		picker.ValueChanged += (pickerSender, pickerArgs) =>
    		{
    			obj.Text = picker.Date.Description;
    		};
    		obj.InputView = picker;
    	}));
    	PresentViewController(d, true, null);
    }
