    [HttpPost]
    public JsonResult ideaExists(string strIdea, int? intIdeaID)
    {
        if (intIdeaID != null)
        {
            if (db.tabIdea.Any(x => x.strIdea == strIdea))
            {
                tabIdea existingTabIdea = db.tabIdea.Single(x => x.strIdea == strIdea);
                if (existingTabIdea.intIdeaID != intIdeaID)
                {
                    return Json(false);
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                return Json(true);
            }
        }
        else
        {
            return Json(!db.tabIdea.Any(x => x.strIdea == strIdea));
        }
    }
