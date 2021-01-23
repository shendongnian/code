    List<string> idList = new List<string>();
    foreach (RepeaterItem ri in Repeater1.Items)
    {
        GridView gvProduct = (GridView)ri.FindControl("gvProduct");
        foreach (GridViewRow gr in gvProduct.Rows)
        {
            CheckBox cb = (CheckBox)gr.FindControl("cbCheckRow");
            if (cb.Checked)
            {
                // add the corresponding DataKey to idList
                idList.Add(gvProduct.DataKeys[gr.RowIndex].Value.ToString());
            }
        }
    }
