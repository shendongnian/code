    protected void ui_dlst_ETLMainInformation_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    
       if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
       {
          Customer c = e.Item.DataItem as Customer;
          DataList innerDataList = e.Item.FindControl("innerDataListControl") as DataList;
    
          List<Customers> customers = ((IList)Session["CustomersCollection"]).Cast<Customers>().ToList();
    
          Customer customer = customers.Find(ct => ct.ID == c.ID);
    
          innerDataList.DataSource = customer.Orders;
          innerDataList.DataBind();
        }
    }
