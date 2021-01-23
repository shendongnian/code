    public static ActionResult CustomAction1(Session session)
    {
    // get property
    Variable = session["PROPERTY"];
    
    // set property
    session["PROPERTY"] = variable;
    
    return ActionResult.Success;
    }
