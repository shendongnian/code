    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selection = DropDownList1.SelectedValue;
        string petPrice = string.Empty;
    
        MySqlCommand cd = new MySqlCommand(String.Format("SELECT Specie_Price FROM pets WHERE Specie ='{0}'",selection), cs);
        cs.Open();
        petPrice = Convert.ToString(cd.ExecuteScalar());
        cs.Close();
    
        petPrice.Text = String.Format("{0}  is £{1}", selection, petPrice);
    } 
