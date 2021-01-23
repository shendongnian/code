    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        // Draw the background of the ListBox control for each item.
        e.DrawBackground();
        // Define the default color of the brush as black.
        Brush myBrush = Brushes.Black;
    
        // Determine the color of the brush to draw each item based  
        // on the index of the item to draw. 
        if (e.Index < 3)
        {
            myBrush = Brushes.Red;
        }
    
        // Draw the current item text based on the current Font  
        // and the custom brush settings.
        e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
        // If the ListBox has focus, draw a focus rectangle around the selected item.
        e.DrawFocusRectangle();
    }
