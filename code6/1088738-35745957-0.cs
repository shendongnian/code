    Dr = cmd.ExecuteReader();
    if (Dr.Read())
    {
        txtReguID.Text = Dr["Registration_ID"].ToString();
        string addmissiondate = Dr["AdmissionDate"].ToString();
        txtAdmissionDate.Text = Convert.ToDateTime(addmissiondate).ToString("MM/dd/yyyy");
    }
