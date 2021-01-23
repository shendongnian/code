    public ActionResult EditExpert(int id)
        {
            ViewBag.listAssistance = new SelectList(objAssistanceRepository.ReturnAssitanceWithoutExpert(), "Id",
                                                    "AssistanceName");
            AssistanceJuror t = new AssistanceJuror();
    
            if (objAssistanceJurorRepository.FindBy(i => i.UserId == id).Count() == 1)
            {
                t = objAssistanceJurorRepository.FindBy(i => i.UserId == id).First();
            }
            return View(t);
        }
