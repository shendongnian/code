    UserControl1 control1 = new UserControl1();
    control1.Dock = DockStyle.Fill;
    control1.SomethingHappened += UserControl1_SomethingHappened; // see below
    panel1.Controls.Clear();
    panel1.Controls.Add(control1);
