    using (Form Login = new Form())
    {
        Login.Controls.Add(new TextBox() { Name="emailtxt", Location = new Point(20, 20) });
        Login.Controls.Add(new TextBox() { Name="passwordtxt", Location = new Point(20, 45) });
        Login.Controls.Add(new TextBox() { Name="worldidtxt", Location = new Point(20, 60) });
        Login.ShowDialog();
    }
