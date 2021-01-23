    private int readPatientData()
            {
                int PatientCount = 0;              
                String strCommand = "select COUNT(*) as PatientCount from Patient_Data where  DummyValue = @MyDummyValue";
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlcommand=new SqlCommand(strCommand,sqlConnection))
                    {
                        sqlcommand.Parameters.Add(new SqlParameter("MyDummyValue", 'Y'));
                        SqlDataReader sqlReader = sqlcommand.ExecuteReader();
                        if (sqlReader.Read())
                            PatientCount = sqlReader.GetInt32(0);
                    }
                }
                return PatientCount;
            }
