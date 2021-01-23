    bool partAdding = false;
    private void PartNameTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        var box = (TextBox)sender;
    
        if (e.Key == Key.Enter)
        {
            var part = (PiecePart)box.DataContext;
            int index = part.ParentPiece.Parts.IndexOf(part);
            if (index == part.ParentPiece.PartCount - 1)
            {
                part.ParentPiece.Parts.Add(new PiecePart(GetNewPartName(part.ParentPiece)));
                UpdateCurrentLine(part.ParentPiece);
                partAdding = true;
            }
            // Gets the element with keyboard focus.
            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
    
            // Creating a FocusNavigationDirection object and setting it to a 
            // local field that contains the direction selected.
            FocusNavigationDirection focusDirection = FocusNavigationDirection.Down;
    
            // MoveFocus takes a TraveralReqest as its argument.
            TraversalRequest request = new TraversalRequest(focusDirection);
    
            // Change keyboard focus. 
            if (elementWithFocus != null)
            {
                elementWithFocus.MoveFocus(request);
            }
        }
    }
    
    private void PartNameTextbox_Loaded(object sender, RoutedEventArgs e)
    {
        if (partAdding)
        {
            var box = ((TextBox)sender);            
            var pp = ((PiecePart) box.DataContext);
            if (pp.IsLastPart)
            {
                box.Focus();
                box.SelectionStart = box.Text.Length;
                partAdding = false;
            }
        }
    }
