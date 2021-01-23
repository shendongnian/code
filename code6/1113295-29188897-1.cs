    [HttpPost]
    public ActionResult Create(Domain.Entities.Survey survey)
    {
        ISurveyRepository surveyRepository = new DbSurveyRepository();
        surveyRepository.CreateSurvey(survey);
        return RedirectToAction("SingleSurvey", new { id= survey.ID, title = survey.Title });
    }
