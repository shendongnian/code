    List<string> list= List<string>();
    if(Session["sku"] != null)
         list = (List<string>)Session["sku"];
    if (validation)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    skuList.Add(row.Cells[2].Text);
                }
            }
        }
    }
    else { Response.Write("<script>alert('At least one product need to be selected!');</script>"); }
    Session["sku"] = skuList;
