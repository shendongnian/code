    public PartialViewResult Agreement(){
        var userId = User.Identity.GetUserId();
        bool hasAgreement = Agreement.HasAgreement(userId); // This will be your model
        return PartialView("Agreement", hasAgreement);
    }
