    public Form _parent;
    
    public Form2(Form Parent)
        {
            InitializeComponent();
    
            this._parent = Parent;
        }
    
    private void button1_Click(object sender, EventArgs e)
        {
            this._parent.textBox1.Text = "prova";
    
        }
