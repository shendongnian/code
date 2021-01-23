    Button btn ;
    private void button1_Click(object sender, EventArgs e)
    {
        btn = new Button();
        btn.Top = 50;
        btn.Left = 50;
        btn.Name = "mybtn";
        btn.Text = "My button";
        this.Controls.Add(btn);
    }
