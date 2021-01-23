    SqlDataAdapter da = new SqlDataAdapter(cmd); // use your existing SqlCommand here
    DataSet ds = new DataSet(); // create a DataSet object to hold you table(s)
    da.Fill(ds, "Comment");  // fill this dataset with everything from the Comment Table
    Repeater1.DataSource = ds.Tables["Comment"];      // attach the data table to the control
    Repeater1.DataBind();                             // This causes the HTML to be automatically rendered when the page loads.
