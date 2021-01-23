    // This goes in the 
    foreach(var button in this.Controls.OfType<Button>())
    {
        button.Mouse += button_IncreaseSize;
    }
    protected override void button_IncreaseSize(MouseEventArgs e)
    {
       // use GetChildAtPoint to get the control
       var button = GetChildAsPoint(new Point(e.X, e.Y));
       // Change the size of button, eg. with Scal, and with the Size property, or by chaning Height and Width propertis manually
       button.Scale(new SizeF(30, 30));
    }
