    // the Area helper class
    public static class AreaHelper
    {
          public static AreaBuilder CustomArea(this HtmlHelper helper)
          {
               return new AreaBuilder().HtmlHelper(helper);
          }
    }
