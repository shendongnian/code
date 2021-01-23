    for (int i = 0; i < data.Count; i++)
    {
       bool itemAlreadyAdded = false;
       foreach (var item in DataListbox.Items)
       {
           if (item.Value == data[i].Value)
           {
                itemAlreadyAdded = true;
                break;
           }
       }
       if (itemAlreadyAdded)
       {
            //do nothing
        }
        else
        {
            DataListbox.Add(data[i]);
        }
    }
