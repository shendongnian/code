    protected void Specialty_SelectedIndexChanged(object sender, EventArgs e)
    {
        //re-populate the Topic dropdownlist to display all the topics based on the following criteria:
        // Where the Specialty column is either "All Specialties" OR "{specialty selected index value}"
        DataTable bookingData2 = (DataTable)ViewState["bookingData2"];
    
        Topic.DataSource = bookingData2.Where(i => i.Specialty == "All Specialties" || i.Specialty == Specialty.SelectedValue).DefaultView.ToTable(true, "Topic"); // populate only with the Topic column
        Topic.DataTextField = "Topic";
        Topic.DataValueField = "Topic";
        Topic.DataBind();
        Topic.Items.Insert(0, new ListItem("All Topics", "All Topics"));
        
    }
