    categorie = GetCategorie();
    if (Request.Cookies["UserInteresse"] == null)
    {
    UserInteresse = new HttpCookie("UserInteresse");
    Response.Cookies.Add(UserInteresse);
    Response.Cookies["UserInteresse"]["Favoriet"] = "Geen";
    }
    else
    {
    UserInteresse = Request.Cookies["UserInteresse"];
    }
    if (Request.Cookies["UserInteresse"][categorie]==null)
    {
    UserInteresse.Values.Add(categorie,"0");
    }
    else
    {
    int nieuwaantal = Convert.ToInt32(Request.Cookies["UserInteresse"][categorie]) + 1;
    UserInteresse.Values.Remove(categorie);
    UserInteresse.Values.Add(categorie, nieuwaantal.ToString());
    if (Convert.ToInt32(Request.Cookies["UserInteresse"][categorie]) >= 7 &&
    (Request.Cookies["UserInteresse"]["Favoriet"].Equals("Geen")||Convert.ToInt32(Request.Cookies["UserInteresse"][categorie]) >
    Convert.ToInt32(Request.Cookies["UserInteresse"][Request.Cookies["UserInteresse"]["Favoriet"]])))
    {
    UserInteresse.Values.Remove("Favoriet");
    UserInteresse.Values.Add("Favoriet", categorie); 
    }
    }
    Response.Cookies.Add(UserInteresse);
    }
