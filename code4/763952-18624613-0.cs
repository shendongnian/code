    protected void dlRange_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataList childDL = e.Item.FindControl("dlComp") as DataList;
            var item = e.Item;
            var dataItem = item.DataItem;
            decimal comID = (decimal)DataBinder.Eval(dataItem, "COMMITTEEID");
            using (BOTEntities context = new BOTEntities())
            {
                var comps = (from comp in context.COMPETENCies
                             join comComp in context.COMMITTEECOMPs on comp.CID equals comComp.CID
                             where comComp.COMMITTEEID == comID
                             orderby comp.NAME
                             select new { comp.CID, comp.NAME }).ToList();
                childDL.DataSource = comps;
                childDL.DataBind();
            }   
        }
    }
