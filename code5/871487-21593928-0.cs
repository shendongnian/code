    public partial class AttedanceManagementJT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nom = Convert.ToInt32(Request.QueryString["ActivityId"]);
            Session["nom"] = nom;
        }
        [WebMethod(EnableSession = true)]
        public static object StudentListByFilter()
        {
            return ApplyMethods.StudentAttendanceList(
                Convert.ToInt32(HttpContext.Current.Session["nom"]));
        }
    }
