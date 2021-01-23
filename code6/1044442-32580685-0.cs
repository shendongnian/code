        protected override void Process(DPFP.Sample Sample)
		{
			base.Process(Sample);
			// Process the sample and create a feature set for the enrollment purpose.
			DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
			// Check quality of the sample and add to enroller if it's good
			if (features != null) try
			{
				MakeReport("The fingerprint feature set was created.");
				Enroller.AddFeatures(features);		// Add feature set to template.
			}
			finally {
				UpdateStatus();
                    // Check if template has been created.
                    
                    switch (Enroller.TemplateStatus)
				{
                       
					case DPFP.Processing.Enrollment.Status.Ready:
                            // report success and stop capturing
                        byte[] serializedTemplate = null;
                        string str_temp = null;
                        DateTime cur_date = DateTime.Now;
                        Enroller.Template.Serialize(ref serializedTemplate);
                        //Enroller.Template.Serialize(ref str_temp);
                            if (serializedTemplate != null)
                        {
                                string result = System.Text.Encoding.UTF8.GetString(serializedTemplate);
                                Console.Write(result);
                                try
                            {
                                    using (NpgsqlConnection conn = new NpgsqlConnection("Host=127.0.0.1;Port=5432;User Id=UserName;Password=*****;Database=finger_print_db;"))
                                    {
                                        conn.Open();
                                      
                                        
                                        NpgsqlCommand dbcmd = conn.CreateCommand();
                                        try
                                        {
                                            // Store TemplateSerialize as string data
                                            
                                            string sqlCom= "INSERT INTO tbl_fptable( fp_id , fp_data ) VALUES ( '" + serializedTemplate + "', '" + cur_date + "', '" + ByteArrayToString(serializedTemplate) + "' )";
                                            dbcmd.CommandText = sqlCom;
                                            dbcmd.ExecuteNonQuery();
                                        }
                                        finally
                                        {
                                            conn.Close();
                                        }
                                    }
                                  
                                }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        OnTemplate(Enroller.Template);
                        SetPrompt("Click Close, and then click Fingerprint Verification.");
						Stop();
						break;
					case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing
						Enroller.Clear();
						Stop();
						UpdateStatus();
						OnTemplate(null);
						Start();
						break;
				}
			}
		}
