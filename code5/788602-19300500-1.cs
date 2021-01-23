    public Form1()
    {
            InitializeComponent();
            //Event fired on Form1_Load
            this.Load += new System.EventHandler(this.button1_Click);
            
    }
    //Event Handler 
    private void button1_Click(object sender, EventArgs e)
    {
        //do something
    }
