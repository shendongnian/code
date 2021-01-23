    Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
    foreach (Assembly asm in asms)
    {
        Response.Write(asm.FullName  + "<br/>");
    }
