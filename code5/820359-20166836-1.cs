    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selection_price = DdPetPist.SelectedValue;
        string selection_stock = DdPetPist.SelectedValue;
        string petPrice = string.Empty;
        string available = string.Empty;
    
        MySqlCommand cd_price = new MySqlCommand(String.Format("SELECT Specie_Price FROM {0}_Animals WHERE Specie ='{1}'", ddlcountry.Text, selection_price), cs);
        MySqlCommand cd_available = new MySqlCommand(String.Format("SELECT Stock FROM {0}_Animals WHERE Specie ='{1}'", ddlcountry.Text, selection_stock), cs);
    
        cs.Open();
        petPrice = Convert.ToString(cd_price.ExecuteScalar());
        available = Convert.ToString(cd_available.ExecuteScalar());
        cs.Close();
    
        PetPrice.Text = String.Format("Minimum Donation For A {0}  Is £{1}.", selection_price, petPrice);
        Availble.Text = String.Format("{0}'s Avalible {1}.", selection_stock, available);
    } 
