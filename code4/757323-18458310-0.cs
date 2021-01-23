      protected void RptrIncdntType_ItemCreated(object sender, RepeaterItemEventArgs e)
      {
        RepeaterItem item = (RepeaterItem)e.Item;
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chkbxSafety = item.FindControl("chkbxSafety") as CheckBox;
            chkbxSafety.CheckedChanged += new EventHandler(CheckBox2_CheckedChanged);
        }
      }
     private void CheckBox2_CheckedChanged(object sender,EventArgs e)
     {
       CheckBox cb = (CheckBox)sender;
     }
