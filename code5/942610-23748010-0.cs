    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
    {
        // Retrieve child visual at specified index value.
        Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
        //How can I check wether childVisual has a Content-Variable or hasn't?
        if(childVisual is ContentControl)
        {
            var childContentVisual = (ContentControl)childVisual;
            var content = childContentVisual.Content;
            ....
        }
        // Enumerate children of the child visual object.
        Translate(childVisual);
    }
    
