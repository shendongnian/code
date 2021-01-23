    namespace Temp
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                List<Company> companyList = new List<Company>{
                    new Company{CompanyID=1,CompanyName="AAAA"},
                    new Company{CompanyID=2,CompanyName="BBBB"},
                    new Company{CompanyID=3,CompanyName="CCCC"},
                    new Company{CompanyID=4,CompanyName="DDDD"},
                };
                childList.DataSource = companyList;
                childList.DataBind();
            }
            [System.Web.Services.WebMethod]
            public static string saveComanyId(string idList)
            {
                string response = "false";
                try
                {
                    var ids = idList.Split(',');
                    foreach (var id in ids)
                    {
                        //Code for saving id in DATABASE
                    }
                    response ="true";
                }
                catch (Exception)
                {
                    response="false";
                }
                return response;
                //returing response true for success and false for failure
            }
            /*protected void chkChildCompany_CheckedChanged(object sender, EventArgs e)
            {
                Response.Write("Child Checkbox is checked, CompanyID: ");
    
            }*/
        }
        public class Company
        {
            public string CompanyName { get; set; }
            public int CompanyID { get; set; }
        }
    }
