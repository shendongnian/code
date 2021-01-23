                 Table tablee = new Table();
                TableRow row1 = new TableRow();
                while (i < 4)
                {
                    TableCell cell = new TableCell();
                    GridView gv = new GridView();
                    gv.ID = i.ToString();
                    gv.DataSource = dt; //dt is your data table that has value...
                    gv.DataBind();
                    cell.Controls.Add(gv);
                    row1.Cells.Add(cell);
                    tablee.Rows.Add(row1);
                   
                  
                   
                    i++;
                }
                PlaceHolder1.Controls.Add(tablee);           
