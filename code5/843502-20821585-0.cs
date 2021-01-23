    GridView gvForCheckBox = (GridView)e.Item.FindControl("gvProduct") as GridView;
    foreach (GridViewRow gr in gvForCheckBox.Rows)
    {
        // I would recommend to match on a PK
        // disclaimer, matching on name may be a problem if two different products can have the same name.
        if (available.Where(x=>x.Name==gr.Cells[1].Text).Any())
        {
            CheckBox cb = (CheckBox)gr.Cells[0].FindControl("cbSelect");
            cb.Checked = true;
        }
    }
