    private void MainForm_Load(object sender, EventArgs e)
    {
        ComboBox box = new ComboBox();
        box.Font = new Font("Comic Sans MS", 100, FontStyle.Regular);
        Controls.Add(box);
    
        Button button = new Button();
        button.Text = "hello world";
        button.SetBounds(box.Left, box.Bottom, 256, 32); 
        Controls.Add(button);
    }
