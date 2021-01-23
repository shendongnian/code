    public ActionResult Test(int id = -1)
    {
       try {
            string pageName =  GetYourPageFromDB(id);
           
            if(!string.IsNullOrEmpty(pageName)) 
                       string directiory = "~Views/folderA/_" + pageName +".cshtml";
               return PartialView(directory);
        }
        catch(Exception ex) {  ... }
        return View();
    }
