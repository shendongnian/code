    @using (Html.BeginForm("Index", "CharterSchoolParameters", FormMethod.Post))
    {
       @Html.DropDownList("selectedScenarioId", Model.ScenarioList)
    }
    
    [HttpPost]
    public ActionResult Index(int? selectedScenarioId)
    {
       /// code...
    }
