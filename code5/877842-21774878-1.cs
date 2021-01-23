    public event EventHandler Lable_TextChanged;
    
    //txtText which will be placed in child form
    private void txtText_TextChanged(object sender, EventArgs e)
    {
        if (Lable_TextChanged != null)
            Lable_TextChanged(sender, e);
    
    }
