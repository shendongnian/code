     void drp_splzn_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DropDownList chosenDropDown = (DropDownList)sender;
            
            Int32 pickedValue = Int32.Parse(chosenDropDown.SelectedValue);
            
            Table table = // new Table();
             (Table)Page.Form.FindControl("table" + chosenDropDown.ID);
            for (int i = 0; i < pickedValue; i++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Attributes.Add("runat", "server");
                TextBox txt_splzn = new TextBox();
                txt_splzn.ID = "txtB_" + chosenDropDown.ID + "_" + i.ToString();
                txt_splzn.Text = "Text Number " + i.ToString();
                txt_splzn.EnableViewState = true;
                cell.Controls.Add(txt_splzn);
                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
            textBoxesStateDictionnary.Add(Int32.Parse(chosenDropDown.ID), Int32.Parse(chosenDropDown.SelectedValue));
           
        }
