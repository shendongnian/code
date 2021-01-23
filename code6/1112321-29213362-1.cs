    protected void inputOwnerTextChanged(object sender, EventArgs e)
        {
            
            DataTable owndept = new DataTable();
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["EMPLOYMENTEXP.HRPRD"].ConnectionString))
            {
                try
                {
                    string NetworkID = inputOwner.Text;
                    OracleDataAdapter adapter = new OracleDataAdapter("select max(vw.DEPTNAME) as DEPTNAME from sysadm.PS_PH_ACTIVE_EE_VW vw where vw.NETWORK_ID = '" + NetworkID + "'", con);
                    
                    adapter.Fill(owndept);
                    outputOwnDept.Text = owndept.Rows[0].Field<String>(0);
                }
                catch (SqlException ex)
                {
                    outputOwnDept.Text = ex.ToString();
                }
            }
        }
