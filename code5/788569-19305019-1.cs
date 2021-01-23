    for (int i = 0; i < ObservableCollectionMenu.Count; i++)
    {
     
        for (int j = 0; j < ((MenuItem)menu1.Items[1]).Items.Count; j++)
        {
             if (((MenuItem)((MenuItem)menu1.Items[1]).Items[j]).Header.ToString().Equals(ObservableCollectionMenu[i].SubMenuColumn))
             {
                ((MenuItem)((MenuItem)menu1.Items[1]).Items[j]).IsEnabled = true;
                 break;
             }
        }
    }
