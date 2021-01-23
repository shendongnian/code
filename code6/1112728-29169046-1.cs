    public HtmlControl MyButton
    {
        get
        {
            HtmlControl target = new HtmlControl(GlobalVariables.Browser);
            target.SearchProperties[propName] = "blah";
            return target;
        }
    }
