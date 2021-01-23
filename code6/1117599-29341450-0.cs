    Outlook.Application myApp = new Outlook.ApplicationClass();
                        Outlook.NameSpace mapiNameSpace = myApp.GetNamespace("MAPI");
                        Object oStoreID = Common.GetFolder(myApp, sFolder).StoreID;
                        try
                        {
                            object obj = mapiNameSpace.GetItemFromID(sEntryID,oStoreID);
                            if (obj is Outlook.MailItem)
                            {
                                Outlook.MailItem getItem = (Outlook.MailItem)mapiNameSpace.GetItemFromID(sEntryID,oStoreID);
                                getItem.Display();
                            }
                        }
