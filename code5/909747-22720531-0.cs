    private void btn_OnMouseEnter(object sender, MouseEventArgs e)
    {
        // example. you can change to a specific type in the Cursors static class
        Cursor.Current = Cursors.WaitCursor;
    }
    private void btn_OnMouseLeave(object sender, MouseEventArgs e)
    {
        Cursor.Current = Cursors.Default;
    }
