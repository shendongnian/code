    event strHandler strChanged;
    delegate void strHandler(string str);
    public Form1()
    {
        InitializeComponent();
        Thread th = new Thread(new ThreadStart(updatethr));
        th.IsBackground = true;
        th.Start();
        strChanged += new strHandler(updatestr);
    }
    BlockingCollection<string> bc = new BlockingCollection<string>();
    public void updatestr(string str)
    {
        bc.Add(str);
    }
    
    private void updatethr()
    {
        while(true)
        {
            string str = bc.Take();
            SystemUtilities.SetControlPropertyThreadSafe(textBox1, "Text", (string)str);
            // Not sure why you need this here, other than simulating a long operation.
            // Thread.Sleep(1000); 
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        this.Text = write();
    }
    
    private string write()
    {
        string res = "";
        strChanged(res);
        for (int i = 0; i <= 5; i++)
        {
            res += i.ToString();
            strChanged(res);
        }
        return res;
    }
