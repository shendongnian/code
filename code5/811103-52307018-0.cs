    public System.Net.Mail.AlternateView GetAlternateView(string MessageText, string LogoPath, bool bSilent)
    {
        
        try
        {
            MessageText += "<br><img title='' alt='' src='cid:SystemEmail_HTMLLogoPath' />";               
    
            System.Net.Mail.AlternateView view = System.Net.Mail.AlternateView.CreateAlternateViewFromString(MessageText, null, "text/html");
            System.Net.Mail.LinkedResource linked = new System.Net.Mail.LinkedResource(HttpContext.Current.Request.PhysicalApplicationPath + LogoPath);
            linked.ContentId = "SystemEmail_HTMLLogoPath";
            view.LinkedResources.Add(linked);
            return view;
        }
        catch (Exception ex)
        {
            if (bSilent)
                return null;
            else
                throw ex;
        }
    }
