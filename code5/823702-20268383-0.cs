    foreach(RepeaterItem item in repeater1.Items)
    {
      foreach (var control in item.Controls)
      {
         if(control.ID.EndsWith("EditMode"))
         {
              control.Visible = false;
         }
      }
    }
