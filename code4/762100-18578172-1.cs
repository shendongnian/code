	private bool triggeredByUser = true ;
	private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{           
		Country country = Countries.Find(x => x.CountryName.Equals(countryComboBox.SelectedItem));
		if (country != null)
		{
			triggeredByUser = false ;
			countryStateListBox.Items.Clear();
			//townListBox.Items.Clear();
			country.countryStateList.ForEach(x => countryStateListBox.Items.Add(x));
			//by default select the first state
			countryStateListBox.selectedIndex = 0 ;
			CountryState state = country.CountryStates.Find(x => x.CountryStateName.Equals(countryStateListBox.SelectedItem));
			
			//refresh the town list based on the country and state
			refreshTownList(country,state) ;
			triggeredByUser = true ;
		}
	}
	private void countryStateListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if(triggeredByUser)
		{
			Country country = Countries.Find(x => x.CountryName.Equals(countryComboBox.SelectedItem));
			CountryState state = country.CountryStates.Find(x => x.CountryStateName.Equals(countryStateListBox.SelectedItem));
			//refresh the town list based on the country and state
			refreshTownList(country,state) ;
		}
	}
	private refreshTownList(Country country,CountryState state)
	{
		if (state != null)
		{
			townListBox.Items.Clear();
			state.Towns.ForEach(x => townListBox.Items.Add(x));
		}
	}
