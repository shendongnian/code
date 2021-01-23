    string s = "";
                foreach (RepeaterItem item in rptInterestCategory.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        Repeater dl = (Repeater)item.FindControl("rptInterests");
                        foreach (RepeaterItem dli in repeatedInterest.Items)
                        {
                            if (dli.ItemType == ListItemType.Item || dli.ItemType == ListItemType.AlternatingItem)
                            {
                                var checkBox = (CheckBox)dli.FindControl("cbInterest");
                                if (checkBox.Checked) { s += (s == "") ? checkBox.Text : "^" + checkBox.Text; }
                                
                            }
                        }
                    }
                }
