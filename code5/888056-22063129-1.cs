    using System;
    using System.Linq;
    public partial class adduserpermission : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
       {
           if (Page.PreviousPage != null)
           {
             if(Page.PreviousPage.IsCrossPagePostBack == true)
             {
                Label1.Text = PreviousPage.Designation;
                Label2.Text = PreviousPage.Department;
                Label3.Text = PreviousPage.Company;
                Label4.Text = PreviousPage.Mobile;
             }
          }
       }
    }
