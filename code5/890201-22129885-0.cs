     if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int quantity = int.Parse(((Label)e.Row.FindControl("lblId")).Text);
    
                switch (quantity)
                {
                    case 1:
                        e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                       
                        break;
                    case 2:
                        e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#00FFFF");
                        break;
                    case 3:
                        e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#0000FF");
                        break;
                    case 4:
                        e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                        break;
                    case 5:
                        e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                        break;            
                   
                }
            } 
     
