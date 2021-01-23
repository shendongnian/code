       bool defaultvalue  = ((CheckBox)row.FindControl("AccessExternal")).Checked;
    // CheckBox chkBx = (CheckBox)row.FindControl("AccessExternal");
                   // if (chkBx.Checked)
                    //{
                     //   defaultvalue = "1";
                   // }
            //  bool defaultvalue  = chkBx.checked ; 
                    cmd.Parameters.Add("@v3", SqlDbType.Bit).Value = defaultvalue;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    i = i + 1;
                    con.Close();
                    con.Dispose();   
