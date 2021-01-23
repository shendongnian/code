                using(SPSite oSite = new SPSite(siteURL))
                {
    
                    using(SPWeb oWeb = oSite.OpenWeb())
                    {
                        SPList list = oWeb.Lists["Rezepte"];
                        SPListItemCollection listItems = list.Items;
    
                        foreach (SPListItem item in listItems)
                        {
                            Console.WriteLine(item.Title);
                        }
                    }              
    
                }
