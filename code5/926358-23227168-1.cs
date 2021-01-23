    private List<int> list = null;
    
    public Form1()
    {
        InitializeComponent();
        Random rnd = new Random();
        list = Enumerable.Range(1, 49).OrderBy(r => rnd.Next()).ToList();
    }
    
    
    private void button1_Click(object sender, EventArgs e)
    {
        if (list.Count == 0)
            throw new InvalidOperationException();
        int randnum = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        MessageBox.Show(randnum.ToString());
    }
