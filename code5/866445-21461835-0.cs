    string[] originalSource = ddlSel1.DataSource as string[];
    if(originalSource != null && ddlSel1.SelectedItem != null)
    {
      ddlSel2.DataSource = originalSource.Except(new [] { ddlSel1.SelectedItem.Value.ToString() });
      ddlSel2.DataBind();
    }
