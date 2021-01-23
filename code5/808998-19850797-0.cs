    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        // Perform any additional setup after loading the view, typically from a nib.
    }
    partial void buttonClick (NSObject sender)
    {
        clickCount++;
        this.CountLabel.Text = clickCount.ToString();       
    }
