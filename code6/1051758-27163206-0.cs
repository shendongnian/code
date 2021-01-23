     public int _accountID;
        public int _securityLevelID;
        public void GetLoginInfo(string EmailAddress, string Password)
        {
            LoginItem l = null;
            {
                try
                {
                    using (RootsDataContext RDC = new RootsDataContext())
                        l = (from a in RDC.DBLogIns
                             where a.EmailAddress == EmailAddress
                             && a.Password == Password
                             && a.IsActive == 1
                             select new LoginItem
                             {
                                 AccountIDFK = a.AccountIDFK,
                                 SecurityLevelIDFK = a.SecurtityLevelIDFK,
                             }).FirstOrDefault();
                  if(l==null || _accountID < 1 || _accountID == null)
                  {
                     lbl_LoginStatus.Text = "Invalid";
                    Response.Redirect("~/InvalidCredentials.aspx"); // redirect to invalid login page.
                  }
                  else
                  {
                   _accountID = (int)l.AccountIDFK;
                    _securityLevelID = (int)l.SecurityLevelIDFK;
                  }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                if (_accountID > 0)
                {
                    if (_accountID == 1 && _securityLevelID == 1) // [Quentin]   
                    {
                        Response.Redirect("~/AccountsMaster.aspx");
                    }
                    if (_accountID > 1 && _securityLevelID == 2) // [Companies]    
                    {
                        Response.Redirect("~/CompanyMaster.aspx");
                    }
                    if (_accountID > 1 && _securityLevelID == 3) // [Branch]
                    {
                        Response.Redirect("~/BranchMaster.Aspx");
                    }
                    if (_accountID > 1 && _securityLevelID == 4) // [Clients]   
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                }
            }
        }    
