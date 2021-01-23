          protected void grdQuestionSet_ItemDataBound(object sender, GridItemEventArgs e)
            {
                if (e.Item.ItemType.Equals(GridItemType.Item))
                //can also check if (e.Item is GridDataItem)
                {
                 Label yourlabel= (e.Item.FindControl("labelId") as Label);
                 //bind your label to data here
                }
            }
