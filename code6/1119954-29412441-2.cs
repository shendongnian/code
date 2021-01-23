    public static readonly DependencyProperty KnobAPushButtonStateProperty = DependencyProperty.Register("KnobAPushButtonState", typeof (bool), typeof (KnobA));
    
    public bool KnobAPushButtonState
    {
    	get { return (bool) GetValue(KnobAPushButtonStateProperty); }
    	set { SetValue(KnobAPushButtonStateProperty, value); }
    }       
    
    
    private void KnobA_MouseDown(object sender, MouseEventArgs e)
    {
    	Mouse.Capture(this);
    	KnobAPushButtonState = true;
    
    private void KnobA_MouseUp(object sender, MouseEventArgs e)
    {
    	Mouse.Capture(null);
    	KnobAPushButtonState = false;
    }
