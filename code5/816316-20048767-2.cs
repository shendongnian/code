    protected void rptTasks_DataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
    
      if (/* logic to determine if task is done At given date by given role */)
      {
        litTask.Name = SomeTask.Name;
      }
    }
