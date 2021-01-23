    //Iterate through the rows of the List View
    foreach (item ListViewItem in lstView.Items)
    {
         //If the control is a data item
         if (item.ItemType = ListViewItemType.DataItem)
         {
              RadioButtonList  rbl = item.FindControl("rblAnswers") as RadioButtonList;
              if(rbl != null)
              {
              //do something
              }
    
              TextBox tb = item.FindControl("txttest") as TextBox;
              if(tb != null)
              {
              //do something    
              }
         }
    }
