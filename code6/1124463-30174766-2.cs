    /// <summary>
    /// Forces a call to Mouse handler. 
    /// This was needed because the events were getting lost when the model was updating
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public void ForceMouseDown(MouseButtonEventArgs e){
        this.OnMouseDown(e);
    }
    
    
    /// <summary>
    /// Invoked when an unhandled MouseDown attached event reaches an element in its route that is derived from this class. 
    /// Implement this method to add class handling for this event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs" /> that contains the event data. 
    /// This event data reports details about the mouse button that was pressed and the handled state.</param>
    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Handled)
        {
            return;
        }
    
        this.Focus();
        this.CaptureMouse();
    
        // store the mouse down point, check it when mouse button is released to determine if the context menu should be shown
        this.mouseDownPoint = e.GetPosition(this).ToScreenPoint();
    
        e.Handled = this.ActualController.HandleMouseDown(this, e.ToMouseDownEventArgs(this));
    }
