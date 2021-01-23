     protected void Button1_Click(object sender, EventArgs e)
        {
           
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
                drp_splzn.AutoPostBack = true ;
                drp_splzn.EnableViewState = true;
                cell.Controls.Add(drp_splzn);
                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
            this.Controls.Add(table);
          
            Page.Form.Controls.Add(table);
            hasDropDowns = true;
        }
