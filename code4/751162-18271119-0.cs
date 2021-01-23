    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (Request.Form.Get("__EVENTTARGET") == Button2.UniqueID)
            return;
        Debug.WriteLine(TextBox2.Text);
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("Text");
    }
