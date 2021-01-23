    Session.Abandon();
    Session.Clear();
    Session.RemoveAll();
    System.Web.Security.FormsAuthentication.SignOut();
    Response.Redirect("frmLogin.aspx", false);
