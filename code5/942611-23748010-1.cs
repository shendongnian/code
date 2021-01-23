    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
    {
        // Retrieve child visual at specified index value.
        Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
        //How can I check whether childVisual has a Content-Variable or hasn't?
        var childContentVisual = childVisual as ContentControl;
        if(childContentVisual != null)
        {
            var content = childContentVisual.Content;
            ...
        }
        // Enumerate children of the child visual object.
        Translate(childVisual);
    }
    
