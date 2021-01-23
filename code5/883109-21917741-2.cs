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
            for (int j = 0; j < Model.Questions[i].Options.Count; j++)
            {
                @Html.RadioButtonFor(m => m.Questions[i].Selected, Model.Questions[i].Options[j].Value) @Model.Questions[i].Options[j].Text
            }
        }
    
        <input type="submit" value="Click" />
    }
