    void button_Click(Object sender,  EventArgs e)
    {
        var button = sender as Button;
        if(button != null)
        {
            button.Text = "X";
            button.ForeColor = System.Drawing.Color.Red;
        }
        
    }
