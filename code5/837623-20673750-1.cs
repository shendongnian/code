    RadGrid1.AllowPaging = false;
    RadGrid1.Rebind();
  
            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {
            }
 
    RadGrid1.AllowPaging = true;
    RadGrid1.Rebind();
