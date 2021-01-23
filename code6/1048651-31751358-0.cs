    public void addClick(object sender, EventArgs e)
    {
        object control;
        string opt = (string) HttpContext.Current.Session["whichMenu"];
    
        switch (opt)
        {
            case "systemDateFormats": control = new WorldViewNet.system.DateFormats();
                break;
            case "programmingLabels": control = new WorldViewNet.programming.Labels();
                break;
            case "programmingPLUSearch": control = new WorldViewNet.programming.PLUSearch();
                break;
            case "programmingServings": control = new WorldViewNet.programming.Servings();
                break;
            case "programmingShops": control = new WorldViewNet.programming.Shops();
                break;
            case "programmingTextsSearch": control = new WorldViewNet.programming.TextsSearch();
                break;
            case "systemTemplates": control = new WorldViewNet.system.Templates();
                break;
            default: new WorldViewNet.system.DefaultType();
        }
    
        ((dynamic)control).addClick();
    }
