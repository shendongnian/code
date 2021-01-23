    public ViewResult View(string viewName,
        [CallerMemberName]string memberName = "")
    {
        if (viewName != memberName)
        {
            throw new ArgumentException("Invalid view name");
        }
        return base.View(viewName);
    }
