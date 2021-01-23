    int dropdownValue = Convert.ToInt32(SignAssetDropDown.SelectedValue);
    
    using (SqlConnection con = new SqlConnection(cs))
    {        
        SqlCommand updateCommand = new SqlCommand("update z_SignAssets set signAsset =@asset where signAssetID =@id",con);
                
        updateCommand.Parameters.AddWithValue("@asset", newNameTextField.Text); 
        updateCommand.Parameters.AddWithValue("@id", dropdownValue);               
        updateCommand.ExecuteNonQuery();        
    }
    UpdateName.Visible = false;
    newNameTextField.Visible = false;
    checkcost.Visible = true;
    EditName.Visible = true;
