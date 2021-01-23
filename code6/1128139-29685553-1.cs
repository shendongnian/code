     private void dgvPoolTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             
            if (e.ColumnIndex == indix your cell1)
            {
                int stutse=1;
                if(e.Value > dgtrans .Rows[e.RowIndex ].Cells [cell2 your index].Value)
                 stutse=1;
               else if(e.Value < dgtrans .Rows[e.RowIndex ].Cells [cell2 your index].Value)
                stutse=2;
                 else
                stutse=3;
                switch (stutse)
                {
                    case 3:
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case 2:
                        e.CellStyle.ForeColor = Color.GreenYellow;
                        break;
                    case 1:
                        e.CellStyle.ForeColor = Color.LawnGreen;
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.BurlyWood;
                        break;
                }
            }
        }
