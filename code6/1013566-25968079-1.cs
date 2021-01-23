        public int InsPatientLanguages(DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            int val = 0;
           
            cmd.Parameters.AddWithValue("@tblPatLanguages", dt);
            val = DAC.SQLHelper.ExecuteNonQuery(cmd, CommandType.StoredProcedure, "dbo.Ins_PatLanguages");
           return val;
        }
