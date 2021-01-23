     protected void Page_Load(object sender, EventArgs e)
        {
             string pID = Convert.ToString(Session["PatientID"]);
                if(!string.IsNullOrEmpty(pID))
                {
                  int patientID = Convert.ToInt32(pID);
                 //Call Stored procedure which will insert this record with this ID
                 // to another table
                }    
                    
        }
