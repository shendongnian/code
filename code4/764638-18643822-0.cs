    void ItemDataBound()
    {
      if(e.Item.ItemType == DataItemType || e.Item.ItemType ==AlternatingItemType)
      {
          var lbl = e.Item.FindControl(lable_id) as Label;
          var hid = e.Item.FindControl(hidden_id) as Hidden;
          
          if(lbl !=null and hid !=null)
          {
              var val = DateTime.Parse(hid.Value);
             // Get the TimeSpan of the difference. 
             TimeSpan elapsed = now.Subtract(val); 
             lbl.Text = string.Format("{0} days ago", elapsed.Days);
          }
    
      }
    }
