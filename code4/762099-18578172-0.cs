    private bool triggeredByUser = true ;
	
	private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {           
        Country country = Countries.Find(x => x.CountryName.Equals(countryComboBox.SelectedItem));
        if (country != null)
        {
			triggeredByUser = false ;
			
            countryStateListBox.Items.Clear();
            townListBox.Items.Clear();
            country.countryStateList.ForEach(x => countryStateListBox.Items.Add(x));
			
			triggeredByUser = true ;
        }
    }
	private void countryStateListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
		if(triggeredByUser)
		{
			Country country = Countries.Find(x => x.CountryName.Equals(countryComboBox.SelectedItem));
			CountryState state = country.CountryStates.Find(x => x.CountryStateName.Equals(countryStateListBox.SelectedItem));// problem here!
			if (state != null)
			{
				townListBox.Items.Clear();
				state.Towns.ForEach(x => townListBox.Items.Add(x));
			}
		}
    }
