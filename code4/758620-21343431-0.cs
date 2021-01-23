    ...
    [RestExtensionMethodAttribute]
    public static string GetCountries() {
     try {
      return Core.RazorRenderer.RenderScriptFile("LandingPage/GetCountries", 0, GetLandingParameters(false));
     } catch (Exception e) {
       return e.ToString();
     }
    }
    ...
