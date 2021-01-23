    private void UpdateList()
    {
      var items = Owner.lstUserOrProject.Items; // Owner represents your admin form
      lstAvailableUser.Items.Clear();
       foreach(var item in items)
       {
          lstAvailableUser.Items.Add(item);
       }
     }
