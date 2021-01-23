    public partial class adduserpermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            adduser prevPage = PreviousPage as adduser;
            if (prevPage != null)
            {
                Label1.Text = prevPage.Designation;
                Label2.Text = prevPage.Department;
                Label3.Text = prevPage.Company;
                Label4.Text = prevPage.Mobile;
            }
        }
    }
