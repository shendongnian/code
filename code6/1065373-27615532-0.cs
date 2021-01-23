        string Name = "Raja";
        Session["name"] = Name; //Assign object to session
        Name = (string)Session["name"]; 
        Name = "Sam"; // Again new assignment of string.
        Response.Write(Session["name"].ToString());
