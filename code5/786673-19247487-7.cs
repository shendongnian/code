    protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["patientid"] != null) you have defined pID as session variable 
            // so check for pID not patientid
           string patientID =Convert.Tostring(Session["pId"]);
             if(!string.IsNullOrEmpty(patientID ))
            {
                lblsession.Text = patientID;
                      //Session["pId"].ToString();
            }
            else 
            { 
    
            }
        }
