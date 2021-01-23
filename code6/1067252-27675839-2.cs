    public class BasicPage : System.Web.UI.Page 
    {
        public SessionContext USession
        {
            get
            {
                if (base.Session["_USRSESS"] != null)
                    return (BO.SessionContext)base.Session[_USRSESS];
                return null;
            }
            set
            {
                base.Session["_USRSESS"] = value;
            }
        }
    }
    public partial class _Default : BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
