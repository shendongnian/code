    Int i = 0;
    foreach(var item in myComboBox.Items)
    {
      if(item.CodeValue = SearchCodeValue)
      {
           return i  // result index
      }
      else
     {
        i = i + 1;
     }
   }
