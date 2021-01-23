    public ActionResult DynamicPage(int id) {
      var dynamicPage = new PagesContext().Pages.FirstOrDefault(s => s.Id == id);
    
      string webroot = Server.MapPath("~").TrimEnd('\\');
      string fileName = webroot + "\\Views\\\\Solutions\\Temp.cshtml";
    
      System.IO.File.WriteAllText(fileName, dynamicPage.Content);
      return View("Temp");
    }
