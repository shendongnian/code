        foreach (Control control in form1.Controls)
        {
            if ((control.GetType() == typeof(DropDownList)))
            {
                ((DropDownList)(control)).DataTextField = "InformationReview";
                ((DropDownList)(control)).DataValueField = "InformationReviewID";
                ((DropDownList)(control)).DataSource = ds.Tables[0];
                ((DropDownList)(control)).DataBind();
                ((DropDownList)(control)).Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }       
    }
