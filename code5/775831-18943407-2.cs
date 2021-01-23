    private void TextBox_Leave(object sender, EventArgs e)
    {
        var box = sender as TextBox;
    
        if(box != null && box.Text.Length > 0)
            box.Text = box.Text.Substring(0, 1).ToUpper() + box.Text.Substring(1);
    }
