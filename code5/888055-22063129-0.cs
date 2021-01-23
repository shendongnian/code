    using System;
    using System.Linq;
    public partial class adduserpermission : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
       {
           Label1.Text = PreviousPage.LabelDesignation;
           Label2.Text = PreviousPage.LabelDepartment;
           Label3.Text = PreviousPage.LabelCompany;
           Label4.Text = PreviousPage.LabelMobile;
       }
    }
