         private void ValidateLogin()
            {
                    string uname = "Hsakarp";//I have hard-coded the value to make it simple
                    string pwd = "12345";
                    string sqlS = "Select UserName,Password from Login where UserName = '" + uname + "' and Password = " + pwd;
            DalAccess dal = new DalAccess();
                        DataSet ds = dal.GetDataSet(sqlS); //GetDataset is gonna return the ds
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["UserName"].ToString().Trim() == uname && ds.Tables[0].Rows[i]["Password"].ToString().Trim() == pwd)
    //Check whether the username and password exists.
                                Label1.Text = "Login Successfull";
                            else
                                Label1.Text = "Login failed";
                        }
    }
