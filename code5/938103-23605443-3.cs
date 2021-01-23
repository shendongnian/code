    context.PostAuthenticateRequest += context_PostAuthenticateRequest; 
    
    void context_PostAuthenticateRequest(object sender, EventArgs e)
    {
        FormsIdentity identity = Thread.CurrentPrincipal.Identity as FormsIdentity;
        if (identity != null)
        {
            HttpContext.Current.Items["__TenantID"] = GetTenantIdFromTicket(identity.Ticket.UserData); // returns tenant_id as guid type
        }
    }
