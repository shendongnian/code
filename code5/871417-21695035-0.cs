    {
    ....
    ....
                PhoneService.WebServiceSoapClient register =
         new PhoneService.WebServiceSoapClient();
                
                register.InsertNewCollegeCompleted += register_InsertNewCollegeCompleted;               
                register.InsertNewCollegeAsync(newCollegeName); 
    ....
    ....
    }
    
      
        void register_InsertNewCollegeCompleted(object sender, PhoneService.InsertNewCollegeCompletedEventArgs e)
            {
                collegeid = e.Result;
        register.insertdataCompleted += register_insertdataCompleted;            
            register.insertdataAsync(Name.Text, email.Text, contact.Text,
                    int.Parse(partnerid.Text.Substring(2)), student_no.Text, pass.Text,
                    gender, branchid, yearid, collegeid, shirtreqd, accom);
            }
        void register_insertdataCompleted(object sender, PhoneService.insertdataCompletedEventArgs e)
        {
            MessageBox.Show("TT ID is" + e.Result);
        }
        
  
