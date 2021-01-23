    protected void txtUpload1_Click(object sender, EventArgs e)
    {
        //Define file upload control as fu
        FileUpload fu = FileUpload1;
        //Check to see if file is present
        if (fu.HasFile)
        {
            //Create StreamReader and pass contents of file
            StreamReader reader = new StreamReader(fu.FileContent);
            //Open SQL connection
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["mike_db"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
                        
            string items = "";
            //Do the following until all file content has been read
            do
            {
                items += reader.ReadLine() + ",";
                                
            }
            while (reader.Peek() != -1);
            //remove last comma
            items = items.Substring(0, items.Length -1);
            string qry = String.Format("select * from prod_class where item IN ({0})", items);
            cmd = new SqlCommand(qry, con);
            queryText.Text = qry;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            //Bind data to the repeater
            My_Repeater.DataSource = ds;
            My_Repeater.DataBind(); 
            reader.Close();
        }
    }
