    private void ResetText(Control Ctrl)
    {
        foreach (Control a in Ctrl.Controls)
        {
            if (typeof(TextBox) == a.GetType())
            {
                ((TextBox)(a)).Text = "";
            }
            else
            {
                ResetText(a);
            }
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            ResetText(this);
        }
        catch 
        {   
            MessageBox.Show("Error!"); 
        }
    }
