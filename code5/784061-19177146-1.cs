    public void GrantAccesOnPage(int AccessPoint1, int AccessPoint2) 
            {
                GlobalVariables.GrantDeny = 0;
                string[] arr = { 
                                   GlobalVariables.SessionPort1, 
                                   GlobalVariables.SessionPort2, 
                                   GlobalVariables.SessionPort3, 
                                   GlobalVariables.SessionPort4 
                               };
                foreach (var r in arr)
                {
                    if (string.IsNullOrEmpty(r))
                    {
                        //remove the comment out only if you want to throw the exception. 
                        //throw new System.ArgumentException("Null");  
                    }
                    else
                    {    
                       if (Convert.ToInt32(r) == AccessPoint1 || Convert.ToInt32(r) == AccessPoint2)
                       {
                            GlobalVariables.GrantDeny = 1;                    
                       }
                    }
                }
                if (GlobalVariables.GrantDeny != 1)
                {
                   Response.Redirect("PageNotAccessable.aspx");
                }
            }
