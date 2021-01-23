    protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["patientid"] != null) you have defined pID as session variable 
            // so check for pID not patientid
           if (Session["pId"] != null)
            {
                lblsession.Text = Session["pId"].ToString();
            }
            else 
            { 
    
            }
        }
