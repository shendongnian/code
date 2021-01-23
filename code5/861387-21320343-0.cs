    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
    
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegDNMembershipConnectionString"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("dbo.P_AddAccount");
            command.Connection = con; 
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@nvcAccountName", TextBoxUN.Text));
            command.Parameters.Add(new SqlParameter("@inyAccountLevelCode", 100));
            command.Parameters.Add(new SqlParameter("inyCharacterCreateLimit", "4"));
            command.Parameters.Add(new SqlParameter("@inyCharacterMaxCount", 4));
            command.Parameters.Add(new SqlParameter("@dt2LastLoginDate", null));
            command.Parameters.Add(new SqlParameter("@vchLastLoginIP", null));
            command.Parameters.Add(new SqlParameter("@@IntLastSessionID", null));
            command.Parameters.Add(new SqlParameter("@vchJoinIP", null));
            command.Parameters.Add(new SqlParameter("@inyPublisherCode", 4));
            command.Parameters.Add(new SqlParameter("@inyGenderCode", null));
            command.Parameters.Add(new SqlParameter("@DaTBirthDate", null));
            command.Parameters.Add(new SqlParameter("@vchPassphrase", TextBoxPass.Text));
            command.Parameters.Add(new SqlParameter("@inyNationalityCode", null));
            command.Parameters.Add(new SqlParameter("@inyChannelPartnerCode", null));
            command.Parameters.Add(new SqlParameter("@EmailAddress", TextBoxEA.Text));
            command.Parameters.Add(new SqlParameter("@FullName", TextBoxFN.Text));
            command.Parameters.Add(new SqlParameter("@Country", DropDownListCountry.SelectedItem));
            command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception er)
        {
            Response.Write("<b>Something Really Bad Happened... Please Try Again.< /br></b>");
            Response.Write(er.Message);
        }
        finally
        {
            //Any Special Action You Want To Add....
        }
    
    }
