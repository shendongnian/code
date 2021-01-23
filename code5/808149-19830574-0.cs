      protected void Session_Start(Object sender, EventArgs e)
      {
         if (User.Identity.IsAuthenticated)
         {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Account/LogOn");
         }
      }
