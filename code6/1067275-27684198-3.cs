      public partial class UsersManagement :MemberWebPage
    {
        public override bool AutorizeUser()
        {
            EnteredUser up = (EnteredUser)Session["UserProfile"];
            if (up == null)
                Response.Redirect("../LogIn.aspx");
            return up.HasAccess(PrimitiveActivity.UserManagement);
        } 
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!AutorizeUser())
                Response.Redirect("../Login.aspx");
        }
    }
