    foreach (RepeaterItem item in Repeater.Items)
    {
      if (item.ItemType == ListItemType.Item 
            || item.ItemType == ListItemType.AlternatingItem) 
        { 
          Label QuestionLabel = (Label)item.FindControl("QuestionLabel");
        }
    }
