    if(!string.IsNullOrEmpty((string)Session["username"]) && (string)Session["username"] == "Anton")
     {
       btnNew.Visible = true;
     }
     else
     {
       btnNew.Visible = false;
     }
