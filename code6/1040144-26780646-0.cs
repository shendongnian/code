    public ActionResult Create(int? id)
        {
    
            var survey = db.Surveys.FirstOrDefault(s => s.SurveyID == id);
            if (survey != null){
                string question = survey.Question1;
                ViewBag.Question1 = question;
            }
            else if (survey == null) { ViewBag.Question1 = "Failed to retrieve Question from database."; }
    
            ViewBag.SurveyID = new SelectList(db.Surveys, "SurveyID", "SurveyName");
    
            return View();
        }
