            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select COUNT(*) as PatientCount from Patient_Data where  DummyValue = 'Y' ", cn))
            {
                try
                {
                    
                    cn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //int Patcount;
                        if (rdr.Read())
                        {
                            int Patcount = int.Parse(rdr["PatientCount"].ToString());
                            if (Patcount != 0)
                            {
                                Label3.Visible = true;
                                Label3.Text = "You have already have "+Patcount+" dummy records,Please update those records by clicking Update Dummy Records Link.";
                                btnSkipSubmit.Visible = false;
                            }
                            //Code Required
                        }
                    }
                }
                catch (Exception ex)
                {
                    // handle errors here
                }
            }
        }
