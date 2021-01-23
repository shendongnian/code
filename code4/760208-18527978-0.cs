    // The page containing this control needs to implement IMasterpage
    public IMasterpage Masterpage { get; set; } 
    void ComboboxCountry_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // Propagate the behavour to your parent page
        Masterpage.CallwatheverMethodInYourInterface();
    }
