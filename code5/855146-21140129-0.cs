    int row = 0;
    int column = -1;
    int left = panelstandard.Controls[0].Left;
    foreach(Control control in panelstandard.Controls)
    {
        // as soon as wrap occurs
        if(control.Left < left)
        {
            // new row
            row++;
            column = 0;
        }
        else
            column++;
        left = control.Left + control.Width; // next control expected left
        // here you know [row; column] of the control
    }
    // here you know total rows and columns
    
