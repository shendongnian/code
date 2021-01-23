            foreach (DataListItem item in dlDelivery.Items)
            {
                if (item.ItemType == ListItemType.Footer)
                {
                    RadioButton rdoOther = (RadioButton)item.FindControl("rdoOther");
                }
            }
