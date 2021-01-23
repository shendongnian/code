       Login UserLogin = new Login();
       UserLogin.Username = textBox1.Text;
       UserLogin.Password = textBox2.Text;
       if(objServiceClientobjService.UserLogin(UserLogin))
             {
                   Response.Redirect("Home.html"); // your page to go after valid user login
             }
         else
             {
                 // show error code
             }
