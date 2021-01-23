    public ActionResult AddExpert(string assistanceJurorId,int UserId)
            {
                var assistanceJuror= //get Your Variable Here;
                User user = objUserRepository.FindBy(i => i.Id == assistanceJuror.UserId).First();
                user.Enable = "فعال";
                assistanceJuror.Date = DateTime.Now;
                objUserRepository.Edit(user);
                objUserRepository.Save();
                objAssistanceJurorRepository.Add(assistanceJuror);
                TempData["Message"] = "کارشناس به معاونت اختصاص داده شد";
                objAssistanceJurorRepository.Save();
                return RedirectToAction("IndexExpert", "Assistance");
            }
