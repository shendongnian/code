     using (SPWeb web = site.OpenWeb())
                {
                   SPList list = web.GetList("Check2");
                   if (list.ItemCount > 0)
                   {
                      SPListItem item = list.Items[0];
                      Hashtable ht = item.Properties;
                      foreach (DictionaryEntry de in ht)
                         Console.WriteLine("Key: {0}  Value: {1}", de.Key, de.Value);
                   }
                }
    }
