    bool shouldSubmit = false;
         // exception handler for empty fields    
                if (cstFName == "")
                {
                    MessageBox.Show("Please enter your first name!");
                }
                else if (cstLName == "")
                {
                    MessageBox.Show("Please enter your last name!");
                }
                else if (cstAddress == "")
                {
                    MessageBox.Show("Please enter your address!");
                }
                else if (cstCity == "")
                {
                    MessageBox.Show("Please enter your city!");
                }
                else if (cstState == "")
                {
                    MessageBox.Show("Please enter your state!");
                }
                else if (cstZip == "")
                {
                    MessageBox.Show("Please enter your zip!");
                }
                else if (cstPhone == "")
                {
                    MessageBox.Show("Please enter your Phone!");
                }
                else if (cstEmail == "")
                {
                    MessageBox.Show("Please enter your email!");
                }
                else
                {
                    shouldSubmit = true;
                    MessageBox.Show("First Name: " + cstFName + " Last Name: " + cstLName + "\r\n" +
                                    "Address: " + cstAddress + "\r\n" +
                                    "City: " + cstCity + " State: " + cstState + " Zip: " + cstZip + "\r\n" +
                                    "Phone: " + cstPhone + " Email: " + cstEmail + "\r\n" + "\r\n" +
                                    "Has been added to the database.");
                }
        
    if(shouldSubmit)
    {
                this.tblCustomersBindingSource.AddNew();
                this.tblCustomersBindingSource.EndEdit();
                this.tblCustomersTableAdapter.Update(this.dataSet1.tblCustomers); // Updating the DB Table  
    }
