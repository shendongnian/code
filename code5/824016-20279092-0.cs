    public void  BindGridview()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["infoConnectionString"].ConnectionString;
                    SqlConnection sqlcon = new SqlConnection(strConnString);
                    sqlcon.Open();
        
                    string strquery2 = "select i.name ,i.score from info as i,Topic as t where  i.topic_id in (select TopicID from Topic where TopicName=@TopicName)";
        
                    SqlCommand cmd = new SqlCommand(strquery2, sqlcon);
                    cmd.Parameters.AddWithValue("@TopicName", ddltopic.SelectedItem.Text);
                    cmd.Connection = sqlcon;
                    SqlDataReader dr; ;
        
                    this.GridView1.DataSource =cmd.ExecuteReader();
                    this.GridView1.DataBind();
                    sqlcon.Close();
    }
