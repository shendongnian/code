    public void getPartyNamesCombo()
    {
    	SqlDataReader reader = new VotingOP().getPartyNamesToCombo();
    	while (reader.Read())
    	{
    		cmbPartyName.Items.Add(new MyDataItem() { 
    			PartyID = reader["partyID"].ToString(), 
    			PartyName = reader["partyName"].ToString() 
    		});
    	}
    	cmbPartyName.ValueMember = "PartyID";
    	cmbPartyName.DisplayMember = "PartyName";
    }
    	
    
