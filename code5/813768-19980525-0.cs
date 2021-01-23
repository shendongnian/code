    for (int i = 0; i < EventInfo.Count; i++)
    {
      ListItem stuff = new ListItem();
      if (!string.IsNullOrWhiteSpace(EventInfo[i]))
      {
        stuff.Text = EventInfo[i];
        //check if condition is met and change bullet style for this item     
        if(condition)
        {
          stuff.Attributes.Add("class", "active");
        }
        BulletedList.Items.Add(stuff);
      }
    }
