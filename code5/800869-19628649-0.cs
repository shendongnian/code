    CheckBox cb = default(CheckBox);
    for (int i = 0; i <= grdforumcomments.Rows.Count – 1; i++)
    {
    	cb = (CheckBox)grdforumcomments.Rows[i].Cells[0].FindControl(“cbSel”);
    
    	cb.Checked = ((CheckBox)sender).Checked;
    }
    
    Select checked rows to a dataset; For gridview multiple edit
    
    CheckBox cb = default(CheckBox);
    foreach (GridViewRow row in grdforumcomments.Rows)
    {
    	cb = (CheckBox)row.FindControl("cbsel");
    	if (cb.Checked)
    	{
    		drArticleCommentsUpdates = dtArticleCommentsUpdates.NewRow();
    		drArticleCommentsUpdates["Id"] = dgItem.Cells[0].Text;
    		drArticleCommentsUpdates["Date"] = System.DateTime.Now;dtArticleCommentsUpdates.Rows.Add(drArticleCommentsUpdates);
    	}
    }
