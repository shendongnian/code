    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        // Perform any additional setup after loading the view, typically from a nib.
    }
    partial void decreaseButtonClick (NSObject sender)
    {
        clickCount++;
        this.CountLabel.Text = clickCount.ToString();       
    }
    partial void increaseButtonClick (NSObject sender)
    {
        clickCount++;
        this.CountLabel.Text = clickCount.ToString();       
    }
