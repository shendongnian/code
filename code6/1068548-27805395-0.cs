    public virtual MvcMailMessage Sample()
    {
        ViewBag.Name = "Test";
        return Populate(x =>{
              x.viewName = "Sample";
              x.To.Add("test@example.com");
            });
    }
