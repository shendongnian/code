    public MainForm()
    {
        ChildForm form = new ChildForm();
        form.FormClosed += OnClosed;  
    }
    public void OnClosed(object sender, EventArgs e)
    {
         this.Show();
    }
