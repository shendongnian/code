    List<string> MyList { get; set; }
    public Form1()
    {
        InitializeComponent();
        MyList = new List<string>(); //Here was wrong.
        var bw = new BackgroundWorker();
        bw.DoWork += (sender, args) => MethodToDoWork();
        bw.RunWorkerCompleted += (sender, args) => MethodToUpdateControl();
        bw.RunWorkerAsync();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 frm2 = new Form2();
        frm2.Show();
        this.Hide();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        lbxPosition.Items.Clear();
    }
    private void MethodToDoWork()
    {
        for (int i = 0; i < 10; i++)
        {
            MyList.Add(string.Format("Temprature {0}", i));
        }
    }
    private void MethodToUpdateControl()
    {
        lbxPosition.Items.AddRange(MyList.ToArray());
    }
