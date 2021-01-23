      public ActionResult CausedOutPoint() {
         var ms = (byte[])Session[ "MS" ];
         return File( ms, "img/png" );
      }
      public ActionResult CausedOutMap(string name)
      {
         var causedOut = new CausedOutViewModel();
         var ms = new MemoryStream();
         causedOut.Chart.SaveImage(ms, ChartImageFormat.Png);
         Session[ "MS" ] = ms.ToArray();
         return Content( causedOut.Chart.GetHtmlImageMap( name ) );
      }
