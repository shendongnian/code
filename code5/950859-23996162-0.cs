    private void cboFunction_SelectedIndexChanged()
        {
            using (SqlConnection con = new SqlConnection(str2))
            {
                string strSQL2= string.empty;
                try
                {
                    int FunID = Convert.ToInt32(cboFunction.SelectedValue);
                    if (FunID != 0)
                    {
                        strSQL2 = "Select [Role_ID], [Role] from [MOS_Role] where [Function_ID] = " + FunID + "";
                    }
                    else
                    {
                        strSQL2 = "Select [Role_ID], [Role] from [MOS_Role]";
                    }
    
    
                    SqlDataAdapter adapter2 = new SqlDataAdapter(strSQL2, con);
                    DataSet DDLRoles = new DataSet();
                    adapter2.Fill(DDLRoles);
    
                   ...
        }
