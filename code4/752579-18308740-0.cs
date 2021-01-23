    protected void AdminUserControl_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            AdminUserControl.EditIndex = e.NewEditIndex;
            UserBLL userbll = new UserBLL();
            AdminUserControl.DataSource = userbll.GetAllUsers();
            AdminUserControl.DataBind();
     
        }
        protected void AdminUserControl_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            UserBLL userbll = new UserBLL();
     
            TextBox fname= (TextBox)e.NewValues["fname"];
            TextBox lname= (TextBox)e.NewValues["lname"];
            TextBox company= (TextBox)e.NewValues["company"];
            TextBox email= (TextBox)e.NewValues["email"];
     
            user = new User();
            user.fname= Convert.ToInt16(fname.Text);
            user.lname= lname.Text;
            user.company= company.Text;
            user.email= email.Text;
     
            admin.UpdateUsers(user);
        }
