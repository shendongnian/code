    public ActionResult DoBinding([MyModelBinder]MyModel myModel)
    {
        return new EmptyResult();
    }
    //inside the view
    <a href="/Home/DoBinding?MyProp1=value1&MyProp2=value2">Click to test</a>
