     if (childNode.Checked)
                            {
    //Checked then insert
    int val = int.Parse(childNode.Value);
    conn.Open();
    string query1 = "UpdatePhotographyCategory";
    SqlCommand cmd1 = new SqlCommand(query1, conn);
    cmd1.CommandType = CommandType.StoredProcedure;
    cmd1.Parameters.AddWithValue("@Subcatid", val);
    cmd1.Parameters.AddWithValue("@ContributorID", this.ContributerID);
    cmd1.Parameters.AddWithValue("@LocationId", Dllscity.SelectedValue);
    cmd1.ExecuteNonQuery();
    conn.Close();
    }
        else
        {
        //unchecked then update or delete
    
    
    }
