    using(SqlConnection conn1 = new SqlConnection(........))
    usin(SqlCommand cmd1 = new SqlCommand("INSERT INTO [pharm_OrderID]" + 
                                          "(UserID, RequestType, CreateDate) " + 
                                          "values (@UserID, @RequestType, @CreateDate);", conn1))
    {
        conn1.Open();
        string strUserID = txtEmpID.Text;
        cmd1.Parameters.Add("@UserID", SqlDbType.NVarChar, 50);
        cmd1.Parameters["@UserID"].Value = strUserID;
    
        string strRequestType = ddlReturnType.SelectedValue;
        cmd1.Parameters.Add("@ReturnType", SqlDbType.NVarChar, 50);
        cmd1.Parameters["@ReturnType"].Value = strRequestType;
    
        string strCreateDate = lblOrderAttemptTime.Text;
        cmd1.Parameters.Add("@CreateDate", SqlDbType.NVarChar, 50);
        cmd1.Parameters["@CreateDate"].Value = strCreateDate;
    
        cmd1.ExecuteNonQuery();
    }
    Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.WizardStep2);
