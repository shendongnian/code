    public Form1()
    {
        InitializeComponent();
        dataGridView1.AutoGenerateColumns = true;
        var source = new BindingList<Comic>(GetComics());
        dataGridView1.DataSource = source;
        dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
    }
    private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
    {
        var dgv = (DataGridView)sender;
        if (dgv.CurrentCell == null) return;
        var dispWidth = dgv.ClientSize.Width - dgv.CurrentRow.HeaderCell.Size.Width;
        int columnsWidthSum = 0;
        for (int i = dgv.CurrentCell.ColumnIndex; i >= 0; i--)
        {
            columnsWidthSum += dgv.Columns[i].Width;
            if (dispWidth >= columnsWidthSum || dispWidth >= dgv.Columns[i].Width)
            {
                dgv.FirstDisplayedScrollingColumnIndex = i;
                break;
            }
        }
    }
