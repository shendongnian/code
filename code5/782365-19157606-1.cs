    protected void RadListView1_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
    {
        dynamic data1 = new[] {
               new { ID = 1, Name ="Name_1",Customdate = DateTime.Now},
               new { ID = 2, Name = "Name_2",Customdate = DateTime.Now},
               new { ID = 3, Name = "Name_3",Customdate = DateTime.Now},
               new { ID = 4, Name = "Name_4",Customdate = DateTime.Now},
               new { ID = 5, Name = "Name_5",Customdate = DateTime.Now}
           };
        RadListView1.DataSource = data1;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = RadListView1.Items.Count();
        RadListView1.AllowPaging = false;
        RadListView1.Rebind();
        int j = RadListView1.Items.Count();
        //Access your count here
        RadListView1.AllowPaging = true;
        RadListView1.Rebind();
    }
