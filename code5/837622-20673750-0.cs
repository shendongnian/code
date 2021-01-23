    RadGrid1.AllowPagging = false;
    RadGrid1.Rebind();
  
            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {
            }
 
    RadGrid1.AllowPagging = true;
    RadGrid1.Rebind();
