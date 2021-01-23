      public ActionResult PrintMyView(int? id, string memberID, int month, int year)
        {
          return new ActionAsPdf( "ViewReport", new { id= id; memberID=memberID; month=month; year=year})
    { FileName = "ViewReport.pdf"};
        }
