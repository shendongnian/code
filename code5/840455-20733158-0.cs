    UserControl1 u1 = new UserControl1();
    UserControl2 u2 = new UserControl2();
    
    // When you want UserControl1.
    u2.Hide();
    u1.Show();
    u1.Dock = DockStyle.Fill;
    panel1.Controls.Add(u1);
    
    // When you want UserControl2.
    u1.Hide();
    u2.Show();
    u2.Dock = DockStyle.Fill;
    panel1.Controls.Add(u2);
