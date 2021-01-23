    foreach (String tag in tags)
            {
                String urls[i];
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell1 = new HtmlTableCell();
                HtmlTableCell cell2 = new HtmlTableCell();
                HtmlTableCell cell3 = new HtmlTableCell();
                LinkButton link = new LinkButton();
                link.Text = "Delete";
                link.ID = "deleteRow" + i;
                cell3.Controls.Add(link);
                ((LinkButton)(cell3.Controls[0])).Click += Delete_Click;
                row.Cells.Add(cell3);
                
                cell1.InnerText = tag;
                row.Cells.Add(cell1);
                cell2.InnerText = url;
                row.Cells.Add(cell2);
                tempTable.Rows.Add(row);
                i++;
            }
        protected void Delete_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
