    private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        string temp = e.Control.Text;
        e.Control.Text += " ";
        e.Control.Text = temp;
    
        if (some_condition)
            e.Control.RightToLeft = System.Windows.Forms.RightToLeft.No;
        else
            e.Control.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
    }
