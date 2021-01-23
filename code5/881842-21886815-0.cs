            var fo = Application.Session.Folders;
            foreach (Outlook.Folder f in fo)
            {
                                
                foreach (Outlook.Folder f2 in f.Folders)
                {
                    
                    var items = f2.Items;
                    mItems.Add(items);
                    items.ItemChange += Items_ItemChange;
                    items.ItemAdd += items_ItemAdd;
                    items.ItemRemove += items_ItemRemove;
                }
            }
