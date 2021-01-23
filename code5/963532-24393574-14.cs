    public Form1()
    {
        InitializeComponent();
        dataGridView1.Controls.Add(indicatorPanel);
        indicatorPanel.Width = 6;
        indicatorPanel.Height = dataGridView1.ClientSize.Height - 39;
        indicatorPanel.Top = 20;
        indicatorPanel.Left = dataGridView1.ClientSize.Width - 21;
        indicatorPanel.Paint += indicatorPanel_Paint;
        dataGridView1.Paint += dataGridView1_Paint;
    }
    Panel indicatorPanel = new Panel();
    List<DataGridViewRow> tgtRows = new List<DataGridViewRow>();
    void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
        indicatorPanel.Invalidate();
    }
    void indicatorPanel_Paint(object sender, PaintEventArgs e)
    {   // check if there is a HScrollbar
        int hs = ((dataGridView1.ScrollBars & ScrollBars.Vertical) != ScrollBars.None ? 20 : 0);
        e.Graphics.FillRectangle(Brushes.Silver, indicatorPanel.ClientRectangle);
        foreach (DataGridViewRow tRow in tgtRows)
        {
            int h = (int)(1f * (indicatorPanel.Height - 20 + hs) * tRow.Index 
                             / dataGridView1.Rows.Count);
            e.Graphics.FillRectangle(Brushes.Red, 0, h-3, 6, 4);
        }
    }
    bool isRowMarked(DataGridViewRow row)
    {
        return row.Cells[0].Style.BackColor == Color.Red;  // <<-- change!
    }
    // call in: dataGridView1_RowsRemoved, dataGridView1_RowsAdded
    // also whenever you set or change markings and after sorting or a filtering
    void findMarkers()
    {
        tgtRows.Clear();
        foreach (DataGridViewRow row in dataGridView1.Rows)
            if (isRowMarked(row) ) tgtRows.Add(row); 
        indicatorPanel.Invalidate();
    }
