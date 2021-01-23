    protected void gridmaterial_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            CheckBox rowcheck = (CheckBox)item.FindControl("chbxmatrow");
            Label lblMaterialDesc = (Label)item.FindControl("lblMaterialDesc");
            TextBox txtQty = (TextBox)item.FindControl("txtQty");
            var result = (from r in MapppedItem.AsEnumerable()
                            where r.Field<int>("MasterMatID") == Convert.ToInt32(item.GetDataKeyValue("MasterMatId").ToString())
                            select r.BOMQty).FirstOrDefault();
            txtQty.Text = result;
    
        }
    }
