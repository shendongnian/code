    foreach (var itm in Model.PasswordResetQuestionUserAnswers)
    {
        @Html.DropDownListFor(modelItem => itm.PasswordResetQuestionId,
                              new SelectList( (IEnumerable<SelectListItem>)ViewData["pwordResetQuestions"], "Value", "Text", itm.PasswordResetQuestionId),
                              htmlAttributes: new { @class = "form-control" }
                            )
    }
   
