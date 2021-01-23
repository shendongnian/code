                using(SPSite oSite = new SPSite(strURL))
                {
    
                    using(SPWeb oWeb = oSite.OpenWeb())
                    {
                        SPList list = oWeb.Lists["Workplan"];
                        SPListItemCollection listItems = list.Items;
    
                        foreach (SPListItem item in listItems)
                        {
                            Console.WriteLine(item.Title);
                        }
                    }              
    
                }
