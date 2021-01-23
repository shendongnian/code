DetailsView.CurrentMode = DetailsViewMode.Edit
    protected void DetailsView1_DataBound(object sender, EventArgs e)
            {
             if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
              {
                DropDownList statusList = DetailsView1.FindControl("StatusList") as
                                          DropDownList;
                    if (statusList != null)
                    {
                        statusList.Items.Add(new ListItem("Test", "Test"));
                        statusList.DataBind();
                    }
                }
            }
