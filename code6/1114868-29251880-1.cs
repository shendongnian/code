    public JsonResult GetCascadeMultipliers()
    {
        return Json(repository.Multipliers.Where(m => m.Status == 1).Select(m => new { ID = m.ID, InstituteName = m.InstituteName }), JsonRequestBehavior.AllowGet); //Sadece aktif kayıtları getir
    }
    public JsonResult GetCascadeParticipants(int? multipliers, string participantFilter)
    {
        var participants = repository.Participants.AsQueryable();
        if (multipliers != null)
        {
            participants = participants.Where(p => p.MultiplierID == multipliers);
        }
        if (!string.IsNullOrEmpty(participantFilter))
        {
            //participants = participants.Where(p => p.Name.Contains(participantFilter)); //Search for the value containing filter
            participants = participants.Where(p => p.Name.StartsWith(participantFilter)); //Search for the value start with filter
        }
        return Json(participants.Select(p => new { ID = p.ID, NameSurname = p.Name + " " + p.Surname }), JsonRequestBehavior.AllowGet);
    }
