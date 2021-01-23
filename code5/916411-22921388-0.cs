    public long getUid()
    {
        try
        {
            string qry = "select isnull(max(Temp_Applicant_RegNo),0) as appregno FROM Temp_Reg";
            if (cs.State == ConnectionState.Closed)
            {
                cs.Open();
            }
            cmd = new SqlCommand(qry, cs);
            dr = cmd.ExecuteReader();
            long cid = 0;
            if (dr.Read())
            {
                cid = long.Parse(dr["appregno"].ToString());
                cid++;
            }
    UPDATE Temp_reg HERE !!!!
            if (cs.State == ConnectionState.Open)
            {
                cs.Close();
            }
            return cid;
        }
        catch (Exception ex)
        {
            lbl_ErrorMsg.Text = ex.Message; 
            return 0;
        }
    }
