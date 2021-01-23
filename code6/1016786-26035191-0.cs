    private void InsertActivationDetail()
    {
        //Mengambil nilai idActivation
        int MaxActivationId = GetGenerateActivationID();
        //
        string id = "";
        foreach (DataListItem objitem in DataListTest.Items)
        {
            /* To get data from the form , then insert into database */
            CheckBox cbCountryName = (CheckBox)objitem.FindControl("cbCountryName");
            HiddenField id_access = (HiddenField)objitem.FindControl("id_access");
            HiddenField id_jenis_access = (HiddenField)objitem.FindControl("idJenisAccess");
            TextBox txtOther = objitem.FindControl("testme") as TextBox;
            TextBox txtreason = objitem.FindControl("txtReason") as TextBox;
            TextBox txtdescription = objitem.FindControl("txtDescription") as TextBox;
            /* Get data end, then Inserting the data (below) */
            /*Check if datalist is null or not*/
            if (objitem != null)
            {
                /*if not nul, then check the checkboxes, is null or not*/
                if (cbCountryName.Checked == true)
                {
                    /*if not null, then insert the data */
                    conn.Open();
                    sql = "INSERT INTO detil_activation (id_activation_access, id_jenis_access, id_access, " +
                         "keterangan, reason, description) " +
                         "VALUES ('" +
                         MaxActivationId + "', '" + id_jenis_access.Value + "', '" + id_access.Value + "','" +
                         txtOther.Text + "','" + txtreason.Text + "','" + txtdescription.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ids += MaxActivationId.ToString() + ",";
                    /* Inserting data is done */
                }
            }
        }
        id = MaxActivationId.ToString();
        Response.Redirect("yourpage?maxID=" + MaxActivationId);
    }
