        protected override void OnLoad(EventArgs e)
        {
            CheckIsSessionExpired();
            //The base method must invoke after CheckIsSessionExpired
            base.OnLoad(e);
        }
        private void CheckIsSessionExpired()
        {
            //Handling Session Expire  
            //This check will not be Applicable for SignIn page 
            //So that we are skipping this            
            //Any other case if session expired then it must redirect to LogOut page
            if (Session["IsExpired"])
            {
                TempBLL.InsertIntotempTable(Session["abc"]);
                Responne.Redirect(SessionExpiredPage);
            }
            
        }
    }
