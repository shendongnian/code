            HtmlTableRow row ;
            HtmlTableCell cell;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                row = new HtmlTableRow();
                cell = new HtmlTableCell();
                cell.Controls.Add(new LiteralControl(drIndentID[i]["RecommentedQuantity"].ToString()));
                row.Cells.Insert(0, cell);
                cell = new HtmlTableCell();
                cell.Controls.Add(new LiteralControl(drIndentID[i]["ProductID"].ToString()));
                row.Cells.Insert(1, cell);
                cell = new HtmlTableCell();
                cell.Controls.Add(new LiteralControl(drIndentID[i]["ProductRequiredDate"].ToString()));
                row.Cells.Insert(2, cell);
                dataTable.Rows.Insert(i, row);//If you want to add new rows after the exist tr use dataTable.Rows.Insert(i+1, row);
            }
