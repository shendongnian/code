    private void InsertActivationDetail()
    {
        // get idActivation
        int MaxActivationId = GetGenerateActivationID();
        //
    
        foreach (DataListItem objitem in DataListTest.Items)
        {
            CheckBox cbNameAccess = (CheckBox)objitem.FindControl("cbNameAccess");
    			if (cbNameAccess != null)
    			{
    				if (cbNameAccess.Checked==true)
    				{
    					conn.Open();
    					sql = "INSERT INTO detil_activation (id_activation_access, id_jenis_access, id_access, " +
    						  "others_all, others_nama_access, call_back_to, reason_any_number, description_other_jenis_access, " +
    						  "reason_others_jenis_access) VALUES ('" +
    						  MaxActivationId + "', (select id_jenis_access from access where id_access = '" +
    						  cbNameAccess.Text + "'), '" + cbNameAccess.Text + "',NULL,NULL,NULL,NULL,NULL,NULL)";
    					SqlCommand cmd = new SqlCommand(sql, conn);
    					cmd.ExecuteNonQuery();
    					conn.Close();
    				}
    			}
            }
        }
    }
