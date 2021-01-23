    public partial class Candidate : System.Web.UI.Page
    {    
        public String CandId {
            get { return Convert.ToString(Session["candidate_id_in_session"]); }
            set { Session["candidate_id_in_session"] = value; }
        }
    }
