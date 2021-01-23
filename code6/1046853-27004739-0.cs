    public PartialViewResult changeTableOnWorkExp(string parameter, string choice, int years, string ischecked)
    {
      var list = (from p in db.Persons where p.YearsOfWorkExperience > years select p).AsEnumerable();
      switch(choice)
      {
        case "Knows Already":
        list =  list.Where(p => p.HobbyProjectICTRelated.Contains(parameter) || p.LearntSkillsAndLevelOfSkills.Contains(parameter));
        case "Wants To Learn":
        ....
      }
      return PartialView("_SearchSkills", list);
    }
