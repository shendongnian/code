    for(int i=0;i<MyGridView.Rows.Count;i++)
    {
        if (Convert.ToDateTime(MyGridView.Rows[i].Cells["TNS_Date"].Value.ToString()) > System.DateTime.Now.Date)
        {
            MyGridView.Rows[i].Cells["TNS_Date"].Style.BackColor = System.Drawing.Color.Red;
        }
    }
