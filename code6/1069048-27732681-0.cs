    for (int i = 0; i < dg1.Rows.Length; i++)
        {
            var now = DateTime.Now.Day;
            var expirationDate = DateTime.Parse(dg1.Rows[i].Cells[2].Value.ToString()).Day;
            if (now == expirationDate)
            {
                dg1.Rows[i].DefaultCellStyle.BackColor = Color.Red; 
            }
        }
