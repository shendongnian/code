     protected void lbInsert_Click(object sender, EventArgs e)
        {
            Event.InsertParameters["Gender"].DefaultValue = ((DropDownList)GridView1.FooterRow.FindControl("ddlGender")).SelectedValue;
            Event.InsertParameters["LastName"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLastName")).Text;
            Event.InsertParameters["FirstName"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtFirstName")).Text;
            Event.InsertParameters["Street"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtStreet")).Text;
            Event.InsertParameters["HouseNr"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtHouseNr")).Text;
            Event.InsertParameters["Zip"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtZip")).Text;
            Event.InsertParameters["City"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
            Event.InsertParameters["Phone"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtPhone")).Text;
            Event.InsertParameters["Email"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;
            Event.InsertParameters["Company"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtCompany")).Text;
            Event.InsertParameters["Active"].DefaultValue = ((DropDownList)GridView1.FooterRow.FindControl("ddlActive")).SelectedValue;
    
            Event.Insert();
            Response.Redirect(Request.Url.AbsolutePath);
        }
