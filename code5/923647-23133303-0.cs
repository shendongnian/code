    protected void Button1_Click(object sender, EventArgs e)
    {
        int number = int.Parse(TextBox1.Text);
        for(int i =  0; i< number ;i++)
        {
            Button btn = new Button();
            btn.ID = "btnSave" + i;
            btn.Text = "Save " + i;
            buttonPanel.Controls.Add(btn);
        }
    }
