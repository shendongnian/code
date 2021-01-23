    public MyHistoryMainControl()
    {
        InitializeComponent();
        editedShipmentGrid.DataSource = handler.GetEditedShipments();
    }
    private void MyHistoryMainControl_Load(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in editedShipmentGrid.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells[54].FormattedValue.ToString()))
            {
                row.DefaultCellStyle.ForeColor = Color.Blue;
            }
            if (string.IsNullOrWhiteSpace(row.Cells[55].FormattedValue.ToString()))
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
        }
    }
