    List<Button> removeList = new List<Button>();
    foreach (Button item in PanelNewFriend.Controls.OfType<Button>())
    {
      if (item.Tag == "0")
      {
        removeList.Add(item);
      }
    }
    foreach (Button item in removeList)
      PanelNewFriend.Controls.Remove(item);
