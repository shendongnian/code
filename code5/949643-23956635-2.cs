    foreach (DevExpress.Web.ASPxGridView.GridViewDataColumn column in grid.Columns)
                    {
                        if (column.FieldName == "Name")
                            column.Caption = "Customer Name";
                        
                        if (column.FieldName == "ID")
                            column.Caption = "Customer ID";
                    }
