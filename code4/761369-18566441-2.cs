    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dynamic data1 = new[] {
               new { ID = 1, Name ="Name_1"},
               new { ID = 2, Name = "Name_2"},
               new { ID = 3, Name = "Name_3"},
               new { ID = 4, Name = "Name_4"},
               new { ID = 5, Name = "Name_5"}
           };
        RadGrid1.DataSource = data1;
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item.IsInEditMode && e.Item is GridEditableItem)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            RadUpload ru = item["AttchColumn"].Controls[0] as RadUpload;
            ru.OnClientFileSelected = "ClientFileSelected";
        }
    }
