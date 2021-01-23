    Form f1;
    void Main()
    {
        f1 = new Form();
        TextBox t1 = new TextBox();
        t1.Location = new Point(0,0);
        TextBox t2 = new TextBox();
        t2.Location = new Point(0,30);
        f1.Controls.AddRange(new Control[] {t1,t2});
        f1.Deactivate += onDeactive;
        f1.Show();
        
        Form f2 = new Form();
        Button b = new Button();
        b.Click += bClick;
        f2.Controls.Add(b);
        
        // This line pass the F1 form
        // as owner of F2 establishing the 
        // correct parent/child behavior
        f2.Show(f1);
    }
    
    void bClick(object sender, EventArgs e)
    {
        Console.WriteLine("Clicked");
        f1.ActiveControl.Text = DateTime.Now.ToString("hh:mm:ss");
    }
    void onDeactive(object sender, EventArgs e)
    {
        Console.WriteLine("Main Deactivated");
    }
