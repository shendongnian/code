    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using c365_EntityFramework;
    using c365_EntityFramework.Repository;
    using ICSWebCommon;
    using ICSWebControls;
    using Obout.Grid;
    using ICSWebPortal.AppCode;
    
    namespace ICSWebPortal.Portal.Controls.Users
    {
        public partial class CreateUser : ICSBaseUserControl
        {
            UserRepository userDao = new UserRepository();
            User user = new User();
            DateTime date = Convert.ToDateTime("2012-09-14 00:00:00.000");
    
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
                if (!String.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    user.Title = txtTitle.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    user.Forename = txtFirstName.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    user.Surname = txtSurname.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    user.Username = txtUsername.Text;
                }
                // call save function at end of statements 
                if (!String.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    user.Address1 = txtAddress.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtAddress2.Text))
                {
                    user.Address2 = txtAddress.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtPostcode.Text))
                {
                    user.PostCode = txtPostcode.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtCode.Text))
                {
                    user.CountryCode = txtCode.Text;
                }
                if (!String.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    user.Email = txtEmail.Text;
                }
    
                user.CompanyID = AppSession.Company.ID;
                user.Status = 1;
                user.PasswordHash = "test";
                user.EntryDate = DateTime.Now;
                user.UpdateDate = DateTime.Now;
                user.Deleted = false;
                bool result = userDao.SaveNewUser(user);
                if (result)
                {
                    Response.Redirect("~/User/List/UserList.aspx"); //~ for root directory , if there is any page use that or use the exact url here.
                }
            }
        }
    }
        
