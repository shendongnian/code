    public List<RoleInfo> Roles
    {
        get
        {
            List<RoleInfo> result = new List<RoleInfo>();
            for (int i = 0; i < lv.Items.Count; i++)
                if (lv.Items[i].ItemType == ListViewItemType.DataItem)
                    lv.UpdateItem(i, true);
    
            //...
    
            return result;
        }
    }
    
    public void lv_UpdateItem(int id)
    {
        RoleInfo model = //...
        TryUpdateModel(model);
    }
