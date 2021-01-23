    public Form1()
    {
        InitializeComponent();
        DataGridView1.CellDoubleClick += New DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
    }
    private void DataGridView1_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
    {
        Form2 frm2 = new Form2();
        frm2.ShowDialig(); //To Show window as a dialog
        //frm2.Show(); //Normal window
    }
