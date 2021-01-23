    protected override void Process(DPFP.Sample Sample)
		{
			base.Process(Sample);
			// Process the sample and create a feature set for the enrollment purpose.
			DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
         
            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
			{
                
                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection("Host=127.0.0.1;Port=5432;User Id=UserName;Password=*****;Database=finger_print_db;"))
                    {
                        conn.Open();
                        try
                        {
                            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM tbl_fptable ORDER BY enr_id DESC LIMIT 1", conn);
                            NpgsqlDataReader dr = cmd.ExecuteReader();
                            while ((dr.Read()))
                            {
                                long fpid = Convert.ToInt64(dr["id"]);
                                byte[] fpbyte = (byte[])dr["finger_data"];
                                Stream stream = new MemoryStream(fpbyte );
                                DPFP.Template tmpObj = new DPFP.Template(stream);
                                
                            
                                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                                // Compare the feature set with our template     
                                Verificator.Verify(features, tmpObj, ref result);
                                UpdateStatus(result.FARAchieved);
                                if (result.Verified)
                                    MakeReport("The fingerprint was VERIFIED.");
                                else
                                    MakeReport("The fingerprint was NOT VERIFIED.");
                            }
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
		}
