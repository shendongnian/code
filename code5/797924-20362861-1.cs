    private int _zindex; //Used to keep the moved element on the top, not working for now
    private FrameworkElement _movedObject; //The element that we're moving. Used to avoid moving multiple items if they overlap
    private void GestureListener_OnDragStarted(object sender, DragStartedGestureEventArgs e)
    {
        if (_movedObject != null) return; // We're already moving something!            
        // Initialize the drag            
        var fe = sender as FrameworkElement; // The element that we want to move
        (fe as Border).BorderThickness = new Thickness(5); // A simple effect to mark the element on the screen
        _movedObject = fe; // We set the current object to the one which is moving
        Canvas.SetZIndex(fe, _zindex++); // This should take the moved object on the top but it's not working
    }
    private void GestureListener_OnDragDelta(object sender, DragDeltaGestureEventArgs e)
    {
        var fe = sender as FrameworkElement;
        if (!fe.Equals(_movedObject)) return; // We change the object's position only if this is the one who started the event
        var offset = DragManager.GetOffset(fe); // We get the current position
        var canvas = DragManager.FindChild<Canvas>(Application.Current.RootVisual, "ItemsCanvas"); // We need the container of our object to force it to stay inside the container
        //The new position is given by the old one plus the change reported by the event
        var horizontalOffset = offset.HorizontalValue + e.HorizontalChange;
        var verticalOffset = offset.VerticalValue + e.VerticalChange;
        // We need to check if the new position is outside our container's bounds
        if (horizontalOffset < 0) horizontalOffset = 0;
        else if (horizontalOffset > (canvas.ActualWidth - fe.ActualWidth)) horizontalOffset = canvas.ActualWidth - fe.ActualWidth;
        if (verticalOffset < 0) verticalOffset = 0;
        else if (verticalOffset > (canvas.ActualHeight - fe.ActualHeight)) verticalOffset = canvas.ActualHeight - fe.ActualHeight;           
        // Once we've got everything set, we can move our component
        DragManager.SetOffset(fe, horizontalOffset, verticalOffset);
    }
    private void GestureListener_OnDragCompleted(object sender, DragCompletedGestureEventArgs e)
    {
        var fe = sender as FrameworkElement;                     
        (fe as Border).BorderThickness = new Thickness(0); // We undo our effect
        _movedObject = null; // The movement is done so we can reset our current object and wait for a new one to come
    }
