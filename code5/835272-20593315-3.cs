    var qry = (from test in  je.employee
                      where test.emp_email.Equals(TxtUserName.Text) & test.emp_pass.Equals(TxtPassword.Text)
                       select test).FirstOrDefault();
       var qry2 = (from test1 in je.employer
                        where test1.c_mail.Equals(TxtUserName.Text) & test1.c_pass.Equals(TxtPassword.Text)
                        select test1).FirstOrDefault();
        if (null!=qry)
        {
            Response.Redirect("EmployeeHome.aspx");
        }
        else if(null != qry2)
        {
             Response.Redirect("EmployerHome.aspx");          
        }
        else
        {
            Label1.Text = "Incorrect username or password!";
        }
