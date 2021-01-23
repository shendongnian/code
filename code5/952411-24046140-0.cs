    // Is sender of type Control?
    Dictionary<Control, string> lookupBasedOnButton = new Dictionary<Control, string>()
    {
        { LinkButtonA, "A" },
        // etc
    };
    Session["LastNameFilter"] = lookupBasedOnButton(sender);
