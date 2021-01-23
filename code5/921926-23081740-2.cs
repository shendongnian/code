        public ActionResult test1()
        {
            var model = new UserSurvey();
            model.Id = 10;
            return View(model);
        }
        [HttpPost]
        public ActionResult test1(SurveyResponseViewModel surveyResponse)
        {
            var x = surveyResponse.Id; // returns 10
            return View(new UserSurvey());
        }
        public class SurveyResponseViewModel
        {
            public int Id { get; set; }
            public Survey Survey { get; set; }
        }
        public class UserSurvey
        {
            public int Id { get; set; }
            public virtual Survey Survey { get; set; }
        }
        public class Survey
        {
            public string Steps { get; set; }
        }
    @model TestWeb.Controllers.UserSurvey
    
    @using (Html.BeginForm())
    {
        <div class="container survey">
            @Html.HiddenFor(x=>x.Id)
    
            @Html.EditorFor(x => x.Survey.Steps)
        </div>
    
        <input type="submit" value="Submit" id="btnSubmit"/>
    }
