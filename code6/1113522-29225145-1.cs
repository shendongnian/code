     protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (!hasDropDowns)
                {
                    return;
                }
                Table table = new Table();
                for (int i = 1; i <= 5; i++)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Attributes.Add("runat", "server");
                    DropDownList drp_splzn = new DropDownList();
                    drp_splzn.ID = i.ToString();
                    drp_splzn.Items.Add("-SELECT SPECIALIZATION-");
                    drp_splzn.Items.Add(new ListItem("1", "1"));
                    drp_splzn.Items.Add(new ListItem("2", "2"));
                    drp_splzn.Items.Add(new ListItem("3", "3"));
                    drp_splzn.Items.Add(new ListItem("4", "4"));
                    drp_splzn.Items.Add(new ListItem("5", "5"));
                    drp_splzn.SelectedIndexChanged += drp_splzn_SelectedIndexChanged;
                    drp_splzn.AutoPostBack = true;
                    drp_splzn.EnableViewState = true;
                    cell.Controls.Add(drp_splzn);
                    row.Cells.Add(cell);
                    table.Rows.Add(row);
                    TableRow rowT = new TableRow();
                    TableCell cellT = new TableCell();
                    cellT.Attributes.Add("runat", "server");
                    Table table2 = new Table();
                    table2.ID = "table" + i.ToString();
                    cellT.Controls.Add(table2);
                    rowT.Cells.Add(cellT);
                    table.Rows.Add(rowT);
                }
                this.Controls.Add(table);
                Page.Form.Controls.Add(table);
            }
            else
            {
            }
        }
