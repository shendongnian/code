    public Form1()
    {
        InitializeComponent();
        dataGridView1.ColumnAdded += dataGrid_ColumnAdded;
    }
    void dataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
        if (e.Column.CellType == typeof(DataGridViewImageCell))
            dataGridView1.Columns.Remove(e.Column);
    }
