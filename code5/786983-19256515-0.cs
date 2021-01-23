    public ActionResult acceptData() {
        Type type = FigureOutWhatTypeToUse();
        object instance = Activator.CreateInstance(type);
        // This allows ASP.NET MVC's model binding to do the dirty work,
        // initializing the properties of your instance based on the submitted
        // parameters.
        TryUpdateModel((dynamic) instance, "myObject"); 
    }
