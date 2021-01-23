    [HttpPost]
    public ActionResult Create(Domain.Entities.Survey survey)
    {
        ISurveyRepository surveyRepository = new DbSurveyRepository();
        surveyRepository.CreateSurvey(survey);
        TempData.Add("surveyID",survey.ID);
        return RedirectToAction("SingleSurvey", new { id = survey.Id, title = survey.Title );
    }
