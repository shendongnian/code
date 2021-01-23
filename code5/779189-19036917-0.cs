    @{
        try
        {
            Html.RenderAction("asdfasdf");   
        }
        catch
        {
            Output.WriteLine("<p>Failed to load asdfasdf</p>");
        }
    }
