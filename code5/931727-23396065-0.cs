    foreach (var item in ddlLst2)
                {
                    ListItem tmp = new ListItem();
                    tmp.Text = item.ToString();
                    tmp.Attributes.Add("AttribName", "AttribValue");
                    DropDownList2.Items.Add(tmp);
    
                }
