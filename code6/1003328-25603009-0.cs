    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!new AuthenticationHelper().IsUserAuthorisedForPeople(Request.User.Identity))
           {
               Response.Redirect("NaughtyNaughty.aspx");
           }
           BindGridView();
        }
    
        public void BindGridView()
        {                      
          PersonHelper helper = new PersonHelper();
          GridView1.DataSource = helper.GetPeople();
          GridView1.DataBind();
        }
    }
    public class AuthenticationHelper()
    {
         public bool IsUserAuthorisedForPeople(string userName) {
            return true; //Do your auth here.
         }
    }
    public class PersonHelper
    {
        private void GetPeople()
        {                      
          List<clsPerson> objPersonList = new List<clsPerson>();
          
          //Populate your list of people.
          
          return objPersonList; 
          //BTW - hungarian notation for your naming is just going to make your 
          //code look cluttered...
        }
    }
