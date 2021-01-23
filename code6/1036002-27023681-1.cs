     while (objReader.Read())
                {
    
                    //Upon reading Clean Data for fresh search
                    cboClientGroup.Items.Clear();
                    cboOccupation.Items.Clear();
                    cboCompany.Items.Clear();
                    cboClientID.Items.Clear();
    
                    //Apply Fresh Search
                    cboClientGroup.Items.Add(Convert.ToString(
                        objReader["Client_Groups"]));
    
                    cboOccupation.Items.Add(Convert.ToString(
                        objReader["Occupation"]));
    
                    cboCompany.Items.Add(Convert.ToString(
                        objReader["Company"]));
    
                    cboClientID.Items.Add(Convert.ToString(
                        objReader["ClientID"]));
    }
