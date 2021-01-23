    if (sender == createButton)
    {
        createButton.Cursor = NativeMethods.LoadCustomCursor(Path.Combine(collection.source, collection.cursor_hand));
        createButton.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.create_on));
    }
     if (sender == otherButton)
     {
         //otherCode
     }
