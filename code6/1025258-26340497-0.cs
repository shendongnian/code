    protected void Session_Start()
    {
        try
        {
            var usuario = new SessionContext().GetUserData();
    
            if (usuario == null) return;
    
            Session.Clear(); //Pode não ser necessário, mas não é problemático o uso como prevenção
            Session.Abandon();
    
            //Limpar o cookie de Autenticação
            var resetFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            resetFormsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(resetFormsCookie);
    
            //Limpar a session cookie
            var resetSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            resetSessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(resetSessionCookie);
    
            //Invalida o Cache no lado do Cliente
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Response.RedirectToRoute("Default");
        }
    }
