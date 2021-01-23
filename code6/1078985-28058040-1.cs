    protected void RefreshSQLDisplay(object sender, EventArgs e)
    {
        foreach (BoundField col in GridView1.Columns)
        {
            if (col.DataField == "WeekEndingDate")
            {
                col.Visible = false;
                break;
            }
        }
    }
