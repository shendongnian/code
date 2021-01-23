    public ActionResult Create(UserViewModel viewModel)
    {
        string destination = Request["Destination"];
        //Create logic...
        return Redirect(destination);
    }
