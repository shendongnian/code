    Protected void Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)   
      {
        CheckBoxList chklst = (CheckBoxList)e.Item.FindControl("chkBoxListGoup");
        for (int i = 0; i < chk.Items.Count; i++)
        {
            if (chk.Items[i].Text == "1")
            {
                chk.Items[i].Selected = true;
            }
        }
      }
    }
