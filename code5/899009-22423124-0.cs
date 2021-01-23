    protected void ddlFacility_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlFacilityType.SelectedItem.ToString() == "Meeting")
        {
            Response.Redirect("number1.aspx");
        }
        else if(ddlFacilityType.SelectedItem.ToString() == "Tutorial" || ddlFacilityType.SelectedItem.ToString()=="Lecture")
        {
            Response.Redirect("number2.aspx");
        }
    }
