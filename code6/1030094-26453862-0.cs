    private DataGridViewColumn columnToMove;
    public Form1()
    {
        InitializeComponent();
        dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "AAA", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn { Name = "BBB", SortMode = DataGridViewColumnSortMode.NotSortable },
                new DataGridViewTextBoxColumn { Name = "CCC", SortMode = DataGridViewColumnSortMode.NotSortable }
            });
        dataGridView1.Rows.Add(2);
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.MouseDown += dataGridView1_MouseDown;
        dataGridView1.ColumnDisplayIndexChanged += dataGridView1_ColumnDisplayIndexChanged;
    }
    private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
    {
        if (e.Column == columnToMove)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            e.Column.Selected = true;
        }
    }
    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        var hti = dataGridView1.HitTest(e.X, e.Y);
        if (hti.Type == DataGridViewHitTestType.ColumnHeader)
        {
            columnToMove = dataGridView1.Columns[hti.ColumnIndex];
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }
    }
