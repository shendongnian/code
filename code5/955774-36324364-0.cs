     private void radGridLedgerAccount_CellFormatting(object sender, CellFormattingEventArgs e)
            {
                if (e.RowIndex == 0  || e.RowIndex==radGridLedgerAccount.Rows.Count-1)
                {
    
                    e.CellElement.DrawFill = true;
                    e.CellElement.ForeColor = Color.White;
                    e.CellElement.NumberOfColors = 1;
                    e.CellElement.BackColor = Color.Red;
                }
                else
                {
                    if (e.CellElement.ColumnInfo.Name == "months") //checking for the text in header cell
                    {
                        if (e.RowIndex != 0)
                        {
                            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#6599FF");
                            e.CellElement.DrawFill = true;
                            e.CellElement.ForeColor = Color.White;
                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = col;
                        }
                    }
    
                    else
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.ForeColor = Color.Black;
                        e.CellElement.NumberOfColors = 1;
                        e.CellElement.BackColor = Color.White;
                        e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                    }
                
                }
