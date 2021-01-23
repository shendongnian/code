    var allItems = Grid_ItemList.Rows.Cast<GridViewRow>()
        .GroupBy(r => new {
            ItemValue = ((DropDownList)r.FindControl("DdlItemName")).SelectedValue,
            ItemCode = ((TextBox) r.FindControl("itemCode")).Text.Trim()
        });
    var duplicates = allItems.Where(g => g.Count() > 1);
    // show somewhere on the page, for example on an error-panel or label
    LblError.Text = "Duplicates detected: " + 
                    string.Join(",", duplicates.Select(d => d.ToString()));
