         if(User.Identity.IsAuthenticated){
            if (User.Identity.Name == "admin")
            {
                DetailsView1.Visible = true;
                //Initial Session if you want 
                Session["CUsername"] = User.Identity.Name;
            }
            else
            {
                Response.Redirect("Page404.aspx");
            }
        }
