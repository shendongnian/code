    private void CustomShape_MouseDown(object sender,
     System.Windows.Input.MouseButtonEventArgs e)
             {
                 OnMouseDownHandler(this);
             }
     
    private void OnMouseDownHandler(object sender)
             {
                 if (MouseDownEvent != null) { MouseDownEvent(sender); }
             }
