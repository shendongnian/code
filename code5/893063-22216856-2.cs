    for(int i=0;i<MyGridView.Rows.Count;i++)
    {
        if (Convert.ToDateTime(MyGridView.Rows[i].Cells[3].Value.ToString()) > System.DateTime.Now.Date)
        {
            MyGridView.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Red;
        }
    }
