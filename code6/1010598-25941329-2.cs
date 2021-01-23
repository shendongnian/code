    const string csname = "ClientEvents";
    const string csurl = "~/js/EtudeCliniqueScript/ClientEvents.js";
    Type cstype = this.GetType();
    ClientScriptManager cs = Page.ClientScript;
    if (!cs.IsClientScriptIncludeRegistered(cstype, csname))
    {
        cs.RegisterClientScriptInclude(cstype, csname, ResolveClientUrl(csurl));
    }
