        protected void Page_Load(object sender, EventArgs e)
    {
      if(IsPostBack)
      {
    try
        {
          SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ERegistrationConnectionString"].ConnectionString);
          conn.Open();
          string checkuser = "select count(*)from Employer where Employer='" + TextBoxEUsername.Text + "'";
          SqlCommand com = new SqlCommand(checkuser, conn);
          int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
          if (temp == 1)
          {
              Response.Write("Username Existed, Please Choose another Username.");
          }
        }
    catch (Exception e)
        {
    //Add your own handling of the Exception here
        }
    finally
        {
          conn.Close();
        }
      }
