    public Form1()
    {
      InitializeComponent();
      DataGridViewCellStyle style = new DataGridViewCellStyle();
      style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridView1.RowHeadersDefaultCellStyle = style;
      this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
    }
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = this.dataGridView1.Rows[e.RowIndex].HeaderCell;
      if (e.ColumnIndex == 0) // (header.Value == null)
      {
        header.Value = String.Format("{0}", e.RowIndex + 1);
      }
    }
