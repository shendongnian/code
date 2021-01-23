    public class WebApiCaseContext : ICaseContext
    {
        public int CurrentCaseId
        {
            get { return (int)HttpContext.Current.Session["CaseId"];
        }
    }
