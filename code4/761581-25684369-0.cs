    public virtual MvcMailMessage Welcome(string email, string fullName)
    {
        //ViewBag.Data = someObject;
        return Populate(x =>
        {
            x.Subject = "Welcome to eTrail Cub Tracking " + fullName;
            x.ViewName = "Welcome";
            x.To.Add(email);
            stmp.send(x);
        });
    }
