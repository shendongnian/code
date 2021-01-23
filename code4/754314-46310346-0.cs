     using (var pa = new InteropWrapper<Outlook.PropertyAccessor>(contact.innerObject.PropertyAccessor))
                {
                    String EMAIL1_ENTRYID = "http://schemas.microsoft.com/mapi/id/{00062004-0000-0000-C000-000000000046}/80850102";
                    string emailEntryID = pa.innerObject.BinaryToString(pa.innerObject.GetProperty(EMAIL1_ENTRYID));
                    using (var rs = new InteropWrapper<Outlook.NameSpace>(Globals.ThisAddIn.Application.Session))
                    {
                        rs.innerObject.Logon();
                        using (var addressEntry = new InteropWrapper<Outlook.AddressEntry>(rs.innerObject.GetAddressEntryFromID(emailEntryID)))
                        using (var exchangeUser = new InteropWrapper<Outlook.ExchangeUser>(addressEntry.innerObject.GetExchangeUser()))
                        {
                            return exchangeUser.innerObject.PrimarySmtpAddress;
                        }
                    }
                }
