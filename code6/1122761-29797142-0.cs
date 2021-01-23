    private void populateView() 
        {
            theView.Refresh();
            try
            {
                DataTable theTable = [query execution];
                DataTable clonedDt = theTable.Clone();
                for (int i = 2; i < clonedDt.Columns.Count -1 ; i++ )
                {
                    clonedDt.Columns[i].DataType = typeof(Boolean);
                }
                    
                foreach (DataRow row in theTable.Rows)
                {
                    clonedDt.ImportRow(row);
                }
                DataView dv = clonedDt.DefaultView;
                theView.DataSource = dv;
                DataGridViewCheckBoxColumn[] checkBoxes = new DataGridViewCheckBoxColumn[20];
                foreach (DataGridViewColumn column in theView.Columns)
                {
                    if (column.Name.Equals("A"))
                    {
                        column.Visible = false;
                    }
                    if (column.Name.Equals("B"))
                    {
                        column.Visible = true;
                        column.ReadOnly = true;
                    }
                    if (column.Name.Equals("C"))
                    {
                        column.Visible = true;
                        column.ReadOnly = true;
                    }
                    if ( column.Name.Contains("D") )
                    {
                        column.Visible = true;
                        column.ReadOnly = false;
                    }   
                }
            }
            catch (Exception e)
            {
                log.Error("Error occured when populating grid", e);
            }
        }
