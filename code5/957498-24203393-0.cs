    public virtual MvcMailMessage Welcome()
    {
        ViewBag.Name = "Sohan";
        return Populate(x =>{
              x.viewName = "Welcome";
              x.To.Add("sohan39@example.com");
            });
    }
