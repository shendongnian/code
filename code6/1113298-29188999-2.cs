    public ActionResult SingleSurvey(int? id)
    {
        if (id != null)
        {
            ISurveyRepository surveyRepository = new DbSurveyRepository();
            Domain.Entities.Survey survey = surveyRepository.GetBySurveyID(id.Value);
            return View(survey);
        }
        return View();
    }
