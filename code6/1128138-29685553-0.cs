     private void dgvPoolTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                int stutse=1; 
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
