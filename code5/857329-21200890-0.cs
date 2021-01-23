    protected void Page_Load(object sender, EventArgs e)
    {
            for (int i = 0; i < 3; i++)
            {
                TableCell cell_name = new TableCell();
                cell_name.Text = "Some name";
                TableCell cell_active = new TableCell();
                CheckBox checkbox = new CheckBox();
                cell_active.Controls.Add(checkbox);
                TableCell cell_actions = new TableCell();
                ImageButton button = new ImageButton();
                button.CommandArgument=i.ToString();
                button.Click += RowClick;
                cell_actions.Controls.Add(button);
                TableRow row = new TableRow();
                row.Cells.Add(cell_name);
                row.Cells.Add(cell_active);
                row.Cells.Add(cell_actions);
                table1.Rows.Add(row);
            }
    }
    protected void RowClick(object sender, EventArgs e)
    {
            int rowIndex =int.Parse( ((ImageButton)sender).CommandArgument);
            Response.Write("RowIndex = " + rowIndex);
    }
