    public Form1()
    {
        InitializeComponent();
        DGVhelper.registerDGV(dataGridView1);
    }
    DGVhelperClass DGVhelper= new DGVhelperClass ();
    class DGVhelperClass 
    {
        public void registerDGV(DataGridView DGV)
        {
            DGV.MouseDown += DGV_MouseDown;
            //...
            DGV.BackgroundColor = Color.LightSlateGray;
            //..
        }
        void DGV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) MessageBox.Show("just", "for show");
        }
    }
