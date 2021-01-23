    private void txtAdrs2A_Leave(object sender, EventArgs e)
    {
        var box = (TextBox)sender;
    
        if(box != null && box.Text.Length > 0)
            box.Text = box.Text.Substring(0, 1).ToUpper() + box.Text.Substring(1);
    }
