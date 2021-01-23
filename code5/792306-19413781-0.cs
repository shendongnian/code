            DropDownList ddlList=DetailsView2.FindControl("ddlPosition") as DropDownList;
            if (ddlList != null)
            {
                if (ddlList.SelectedItem.Text.Contains("text")) {
                            args.IsValid = false;    
                }
                 else
                {
                       args.IsValid = true;
                }
            }    
