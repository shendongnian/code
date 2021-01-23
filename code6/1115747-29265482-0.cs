    public partial class RWCMSMain : System.Web.UI.MasterPage
    {
        private Business.BusinessEntities.User m_LoggedOnUse;
    
        public Business.BusinessEntities.User LoggedOnUser 
        { 
             get
             {
                  if (this.m_LoggedOnUse == null)
                      this.m_LoggedOnUse = userRepo.GetUser(securityToken);
                  
                  return this.m_LoggedOnUse;
             } 
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
