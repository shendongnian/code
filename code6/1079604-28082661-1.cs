    public bool ReAssignLicense(string certificateID, string serialNumber, string newEmail, string ticketID, string backupBy, string customerName, DateTime? expDate)
    {
      List<SqlParameter> ParaList = new List<SqlParameter>();
      ParaList.Add(new SqlParameter("@certificate", certificateID));
      ParaList.Add(new SqlParameter("@certSN", serialNumber));
      ParaList.Add(new SqlParameter("@newemail", newEmail));
      ParaList.Add(new SqlParameter("@ticket", ticketID));
      ParaList.Add(new SqlParameter("@bkpBy", backupBy));
      ParaList.Add(new SqlParameter("@customer_name", customerName));
      if (expDate != null)
        ParaList.Add(new SqlParameter("@exp_date", expDate));
      return SqlHelper.ExecuteNonQuery(new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString), CommandType.StoredProcedure, "sp_Update", ParaList.ToArray()) > 0;
    }
