    private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
            {
                DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
    
                if (e.Column.FieldName == "XYZ")
                {               
                    string strCellValue = View.GetRowCellDisplayText(e.RowHandle, View.Columns["XYZ"]);
                    int inStockCol = e.RowHandle;
                    if (!strCellValue.Equals("NA"))
                    {
                        double dblCellValue = Convert.ToDouble(strCellValue);
                       
                        if (dblCellValue < 0 || dblCellValue > 1000)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.LightPink;                      
                          
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.BackColor2 = Color.LightGreen;
                        }
                    }
                    
                }
    }
