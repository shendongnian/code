    DataRowView row = (DataRowView)DetailsView1.DataItem
    ListItem liCountry = ddlCountry.Items.FindByText(row["Column_Name"].ToString());
    if (liCountry != null)
      {
        ddlCountry.Items.FindByText(row["Column_Name"].ToString()).Selected = true;
      }
