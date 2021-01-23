    using (SPSite _site = new SPSite(SiteUrl))
                {
                    using (SPWeb _web = _site.OpenWeb())
                    {
                        SPList oList = _web.Lists[List];
                        SPQuery _query = new SPQuery();
                        _query.Query = "<Where><Eq><FieldRef Name='"+Column+"' /><Value Type='Text'>"+Value+"</Value></Eq></Where>";
                        SPListItemCollection _itemCollection = oList.GetItems(_query);
                        if (_itemCollection.Count > 0)
                        {
                            _web.AllowUnsafeUpdates = true;
                            foreach (SPListItem Item in _itemCollection)
                            {
                                Item[updateCol] = updateVal;
                                Item.Update();
                            }
                            _web.AllowUnsafeUpdates = false;
                        }
                    }
                }
