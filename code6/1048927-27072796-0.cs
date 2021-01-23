    namespace MyApp
    {
      namespace ShortCodes 
      {
        public static class RenderMisc 
        {
          public readonly string PrivacyPolicy = 
            "<div id='privacy'><strong>This is the privacy policy.</strong></div>";
        
          public string GenerateCopyright() 
          {
            return "<div id='copy'><strong>Copyright " 
              + DateTime.Now.Year.ToString() 
              + ".</strong></div>";
          }
          public reaonly string HamburgerRecipe =
            "<div id='recipe'><strong>Use Hamburgers and Buns.  Beans are a nice side.</strong></div>";            
        }
      }
    }
