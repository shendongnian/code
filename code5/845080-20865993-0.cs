    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        dr = cmd.ExecuteReader();
        dr.Read();
        dt= (DateTime)dr[0];
        if(dt!= null)
        {       
            if(dt == e.Day.Date)
              {
                 e.Cell.BackColor = System.Drawing.Color.Red;
              }
        }
    }
