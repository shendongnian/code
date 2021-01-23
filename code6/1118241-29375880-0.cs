    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            PopulateFloorRow();
        }
    }        
    protected void cmb_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFloorRow();
    }
    private void PopulateFloorRow()
    {
        floorTable.Rows.Clear();
        for (int i = 0; i < 2; i++)
        {
            TableRow tableRow = new TableRow();
            tableRow.Cells.Add(new TableCell());
            tableRow.Cells.Add(new TableCell());
            tableRow.Cells[0].Controls.Add(new Label() { Text = cmb.SelectedItem.Text });
            Button button = new Button();
            button.ID = "btn" + i.ToString();
            button.Text = "Click";
            button.Click += button_Click;
            tableRow.Cells[1].Controls.Add(button);
            floorTable.Rows.Add(tableRow);
        }
    }
    void button_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
