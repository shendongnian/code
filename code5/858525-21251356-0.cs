    protected void Button_Click(Button sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
            if (btn.Text == " ")
            {
                pushthebutton();
                gamecheck();
            }
        }
    }
