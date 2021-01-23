        public void GetDataFromSProc(object sender, EventArgs e)
        {
            SqlConnection SConnect = new SqlConnection();
            SqlCommand SCommand = new SqlCommand();
            SqlDataAdapter SAdaptor = new SqlDataAdapter();
            SConnect.Open();
            // in the next line you execute your SProce with form controls content
            SCommand.CommandText = "exec [dbo].[MJTestProc] '" + RadioButton1.Text + "' , '" + DatePicker1.Text + "' , '" + DatePicker2.Text + "'";
            DataTable dt = new DataTable();
            SAdaptor.Fill(dt);
            SConnect.Close();
            //here you can assign dt content to a control 
        }
