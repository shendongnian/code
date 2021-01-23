    string connstring =     System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    SqlConnection conn = new SqlConnection(connstring);
    SqlCommand cmd = new SqlCommand("INSERT INTO PARTS VALUES('" + nameBox.Text + "', '" + descriptionBox.Text + "', '" + quantityBox.Text + "', '" + categoryList.SelectedValue + "')"
                                   , conn);
    cmd.ExecuteNonQuery();
