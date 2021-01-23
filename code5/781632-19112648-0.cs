     foreach (CenterInfo centerInfo in Data.CenterDB.GetCenterByCityId(city.ID))
                    {
                        ListItem listitem = new ListItem();
                        listitem.Value = centerInfo.ID.ToString();
                        listitem.Text = centerInfo.CenterName;
                        CenterNameDropDownList.Items.Add(listitem);
                    }
