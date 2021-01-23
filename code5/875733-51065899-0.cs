    public void SelectFill(DataTable dtResult, HtmlSelect htmlSelect, string placeHolder, string textColumn, string valueColumn, string value)
        {
            htmlSelect.DataSource = dtResult;
            htmlSelect.DataTextField = textColumn;
            htmlSelect.DataValueField = valueColumn;
            htmlSelect.DataBind();
            
            bool isMultiple = false;
            foreach (var item in htmlSelect.Attributes.Keys)
            {
                if (item.ToString() == "multiple")
                {
                    isMultiple = true;
                }
            }
            
            if (isMultiple)
            {
                htmlSelect.Attributes["data-placeholder"] = placeHolder;
            }
            else
            {
                ListItem placeHolderItem = new ListItem(placeHolder, "-1");//create placeholder option for non multible selectbox
                placeHolderItem.Attributes.Add("disabled", "disabled");
                htmlSelect.Items.Insert(0, placeHolderItem);
                htmlSelect.Items[0].Selected = true;
            }
        }
