    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                switch (e.CommandName)
                {
                    case "click":
                        {
                            // Populate Person Details                        
                            PersonBL objPersonBL = new PersonBL();
                            var objPerson = objPersonBL.GetPersonSingleByPersonID(e.CommandArgument.ToString());
    
                            //Person objPerson = new Person();
                            if (objPerson.Count != 0)
                            {
                                txtPersonID.Text = objPerson[0].PersonID;
                                txtFirstname.Text = objPerson[0].Firstname;
                                txtLastname.Text = objPerson[0].Lastname;
                                break;
                            }
                        }
                    default:
                        break;
                }
            }
