    int intValue;
     
    if (int.TryParse(e.Value, out intValue) && intValue <= 5)
    {
        e.CellStyle.BackColor = Color.Red;
        e.CellStyle.SelectionBackColor = Color.DarkRed;
        e.CellStyle.ForeColor = Color.White;
        if (!e.CellStyle.Font.Bold)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }
