    UIView _topKeyboard = new UIView();
    
    UIButton _prev = new UIButton(UIButton.Type.System);
    _prev.SetTitle("Prev", UIControlState.Normal);
    _prev.Frame = new RectangleF(0,0, 100,20);
    _prev.TouchUpInside += (object sender, EventArgs e) => {
     // Add the function of the key
    };
    
    UIButton _next = new UIButton(UIButton.Type.System);
    // Set as above
    UIButton _done = new UIButton(UIButton.Type.System);
    // set as above
    
    // now addit to the view
    
    _topKeyboard.Add(_prev);
    
    _topKeyboard.Add(_next);
    
    _topKeyboard.Add(_done);
