         void Session_End(object sender, EventArgs e) 
         {
            if(!String.IsNullOrEmpty((string)Session["Name"]))
            {
                Application.Lock();
                Application["UsersOnline"] = (int)Application["UsersOnline"] -1 ;
                Application.UnLock();
            }
         }
