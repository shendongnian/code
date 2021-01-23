    Controls.Button btn = new Controls.Button();
    btn.ID= "ID" + counter;
    btn.button1.Text = "Details";
    btn.Location = new Point(200, cnt);
    btn.Click += button1_Click;
    panel1.Controls.Add(btn);
