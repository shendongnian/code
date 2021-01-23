    private void bindGridView()
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            //get connection string from web.config
            string strConnectionString = ConfigurationManager.ConnectionStrings["sacpConnectionString"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
    
     string strCommandText = "SELECT pat.pFirstName AS FirstName, aStatus AS Status,  COnvert(VARCHAR(15),aDate,103) AS Date, aTime AS Time, aContact AS Contact, aHeight AS Height, aWeight AS Weight, med.mcCentre AS MedicalCentre from appointment AS app ";
        strCommandText += " LEFT OUTER JOIN MEDICALCENTRE as med on app.mcid = med.mcid";
        strCommandText += " LEFT OUTER JOIN PATIENT as pat on app.patientid = pat.patientid ";
        strCommandText += " WHERE app.patientid = " + ID.ToString();
    
            try
            {
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
    
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
    
                DataTable dt = new DataTable();
                dt.Load(reader);
                grdViewAppointment.DataSource = dt;
                grdViewAppointment.DataBind();
                lblResult.Text = "";
    
                reader.Close();
            }
            catch (SqlException ex)
            {
                lblResult.Text = "Error:" + ex.Message.ToString();
            }
            finally
            {
                myConnect.Close();
            }
    
        }
    }
       
