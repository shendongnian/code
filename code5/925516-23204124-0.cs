        public ActionResult DoStuff(ModelClass mc,string btnPrev,string btnNext)
    {
      string actionString = "previousPage";
      if(btnNext != null)
         actionString = "nextPage";
    
    
      return RedirectToAction(actionString,"Controller")
    }
