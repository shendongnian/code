    public ActionResult EditExpert(int userid)
    {
        ViewBag.listAssistance = new SelectList(objAssistanceRepository.ReturnAssitanceWithoutExpert(), "Id",
                                                "AssistanceName");
        AssistanceJuror t = new AssistanceJuror();
    
        if (objAssistanceJurorRepository.FindBy(i => i.UserId == userid).Count() == 1)
        {
            t = objAssistanceJurorRepository.FindBy(i => i.UserId == userid).First();
        }
        return View(t);
    }
