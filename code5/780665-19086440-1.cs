    string myViewName = viewName;
    switch (ThemeContext.GetTheme())
    {
        case "Blue":
            myViewName += ".blue";
            break;
        case "Red":
            myViewName += ".red";                
            break;
    }
    if (mobileViewShouldNotBeDisplayed)
    {
       ViewLocationFormats = new[]
       {
          	"~/Views/{1}/{0}.cshtml"
       }; 
    }
    if (mobileViewShouldBeDisplayed)
    {
       ViewLocationFormats = new[]
       {
          	"~/Views/{1}/Mobile/{0}.cshtml"
       }; 
    }
