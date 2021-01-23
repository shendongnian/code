    protected void Button1_Click(object sender, EventArgs e)
    {        
        DataTable dt = new DataTable();
        for (int i = 0; i < 10; i++)
            dt.Columns.Add("col" + i.ToString(), typeof(int));
        Random r = new Random();
        List<int> l = new List<int>(100);
        int temp=0;
        for (int i = 9; i >= 0; i--)
        {
            DataRow dr = dt.NewRow();
            for (int j = 0; j < 10; j++)
            {
                temp = r.Next(99);
                if (!l.Contains(temp) || (j == 0 && i == 0))
                {
                    dr["col" + j.ToString()] = temp;
                    l.Add(temp);
                }
                else
                    j -= 1;
            }
            dt.Rows.Add(dr);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
