    for(int i = 0; i < model.Count; i++)
    {
      if (model[i].RuleId == 1) && (model[i].Comments == null)
      {
        string propertyName = string.Format("[{0}].Comments", i); // returns "[0].Comments", "[1].Comments" etc
        ModelState.AddModelError(propertyName , "error message");
      }
    }
