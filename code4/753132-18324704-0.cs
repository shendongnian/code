    private DateTimePicker cellDateTimePicker;
    private List<int> dateColumnsIndexes;
         
    public MainForm()
    {
      InitializeComponent();
      /// 
      this.cellDateTimePicker = new DateTimePicker();
      this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
      this.cellDateTimePicker.Visible = false;
      this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy";
      this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
      this.dataGridView1.Controls.Add(cellDateTimePicker);
      (...)
    }
    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      var index = masterDataGridView.CurrentCell.ColumnIndex;
      if (this.dateColumnsIndexes.Contains(index))
      {
        Rectangle tempRect = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);          
        cellDateTimePicker.Location = tempRect.Location;
        cellDateTimePicker.Width = tempRect.Width;
        try
        {
          cellDateTimePicker.Value = DateTime.Parse(dataGridView1.CurrentCell.Value.ToString());
        }
        catch
        {
          cellDateTimePicker.Value = DateTime.Now;
        }
        cellDateTimePicker.Visible = true;
      }
    }
    void cellDateTimePickerValueChanged(object sender, EventArgs e)
    {
      masterDataGridView.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
      cellDateTimePicker.Visible = false;
    }
    private void AddCalendars(DataGridView dtgv)
    {
      dateColumnsIndexes = new List<int>();
      dtgv.DataSource = controller.getEmptyDataTable();     // DataTable provided by excel reader
      var l = dtgv.Columns.Count;
      string[] dateColumns = {"date_received", "date_of_birth"};
      for (var i = 0; i < l; ++i)
      {
        if ( dateColumns.Any( dtgv.Columns[i].HeaderText.Contains )
        {
          dateColumnsIndexes.add(i);
        }
     }
   }
