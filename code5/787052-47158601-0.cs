          protected void gvItems_RowCreated(object sender, GridViewRowEventArgs e)
          {                    
                    GridViewRow NewHeader = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    NewHeader.Font.Bold = true;
                    NewHeader.CssClass = "heading";
                    //Item#
                    TableCell NewHeaderCell = new TableCell();
                    NewHeaderCell.Text = "#";
                    NewHeaderCell.HorizontalAlign = HorizontalAlign.Left;
                    NewHeader.Cells.Add(NewHeaderCell);
                    //Item#
                    NewHeaderCell = new TableCell();
                    NewHeaderCell.Text = "Item#";
                    NewHeaderCell.HorizontalAlign = HorizontalAlign.Left;
                    NewHeader.Cells.Add(NewHeaderCell);
                    //Amount
                    NewHeaderCell = new TableCell();
                    NewHeaderCell.Text = "Amount";
                    NewHeaderCell.HorizontalAlign = HorizontalAlign.Right;
                    NewHeader.Cells.Add(NewHeaderCell);
                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewHeader);
           }
