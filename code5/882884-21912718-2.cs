    @model MVC.Controllers.QuestionMainModel
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    @using (Html.BeginForm("Submit", "sample", FormMethod.Post))
    {
    
        for (int i = 0; i < Model.Questions.Count; i++)
        {
            @Html.HiddenFor(m => m.Questions[i].Id)
            @Html.LabelFor(m => m.Questions[i].Text, Model.Questions[i].Text)
            @Html.DropDownListFor(m => m.Questions[i].Selected, new SelectList(Model.Questions[i].Options, "Value", "Text"), "Select an option")
        }
    
        <input type="submit" value="Click" />
    }
