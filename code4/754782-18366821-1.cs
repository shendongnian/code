    private Form MyParent { get; set; }
    public Form1(Form parent)
    {
       MyParent = parent;
    }
    MyParent.Show();
