    ListBox l = new ListBox();
    BindingSource bs = new BindingSource();
    void Main()
    {
        Form f = new Form();
        Button b = new Button();
        b.Click += onclick;
        b.Dock = DockStyle.Bottom;
        
        List<string> ls = new List<string>()
        {"Steve", "Mark", "John"};
    
        bs.DataSource = ls;
        l.Dock = DockStyle.Fill;
        l.DataSource = ls;
        
        f.Controls.Add(b);
        f.Controls.Add(l);
        f.Show();    
    }
    
    void onclick(object sender, EventArgs e)
    {
        if(l.SelectedIndex != -1)
        {
            bs.RemoveAt(l.SelectedIndex);    
        }
    }
