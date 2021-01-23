    public ActionResult Votation(PostedCandidates PostedCandidates)
    {
        CandidatesViewModel vm = new CandidatesViewModel();
        //process or fill your viewmodel here.
        return View(vm);
    }
    
