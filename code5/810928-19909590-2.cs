        public abstract class BasePage : Page
        {
            protected override void OnLoad(EventArgs e)
            {
                CheckIsSessionExpired();
                //The base method must invoke after CheckIsSessionExpired
                base.OnLoad(e);
            }
            private void CheckIsSessionExpired()
            {
                //Handling Session Expire                  
                //Any other case if session expired then it must redirect to LogOut page
                if (Session["IsActive"]==null)
                {
                    TempBLL.InsertIntotempTable("some data");
                    Responne.Redirect(SessionExpiredPage);
                }
            }
        }
