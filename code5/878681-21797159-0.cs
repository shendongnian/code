    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string role;
    
            var sessionValue = Session["Roles"];
            if (sessionValue != null)
               role = sessionValue.ToString();
    
            else
            {
              string MyPage = System.IO.Path.GetFileName(Request.Path);
              SqlDataReader RolePageDr = BLL.Users.RolesPage(MyPage);
              while (RolePageDr.Read())
              {
                role = RolePageDr["Roles"].ToString();
                Session["Roles"] = role;
              }
            }
    
            if (Page.User.IsInRole(Rolepage) != true)
            {
                    Response.Redirect("~/MsgPage.aspx");
            }
            else
                    Response.Redirect(MyPage);
        }
    }
