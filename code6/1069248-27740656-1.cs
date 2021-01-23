    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
              e.Item.ItemType == ListItemType.AlternatingItem)
           {
              DataSet ds = new DataSet();
              ds = cls.ReturnDataSet("sp_data",
                     new SqlParameter("@From_Time", "2014-11-01 00:00:00.000"),
                    new SqlParameter("@To_Time", "2014-11-03 00:00:00.000"));         
            Label Label1 = (Label)e.Item.FindControl("Label1");
            Repeater rpt = (Repeater)e.Item.FindControl("Repeater2");
            var source = ds.Tables[1].AsEnumerable()
                    .Where(x => x.Field<int>("Id") == Convert.ToInt32(Label1.Text))
                    .Select(x => new 
                          { 
                              stptime= x.Field<DateTime>("stptime")
                          });
           rpt.DataSource = source ;
           rpt.DataBind();
          }
    }
