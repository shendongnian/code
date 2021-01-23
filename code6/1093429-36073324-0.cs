    @model bool?
    @{
        var selectList = new List<SelectListItem>
        {
            new SelectListItem {Text = "(Any)", Value = String.Empty, Selected = !Model.HasValue},
            new SelectListItem {Text = "Yes", Value = "true", Selected = Model.HasValue && Model.Value},
            new SelectListItem {Text = "No", Value = "false", Selected = Model.HasValue && !Model.Value}
        };
        object htmlAttributes = null;
        if (ViewData != null && ViewData["htmlAttributes"] != null)
        {
            htmlAttributes = ViewData["htmlAttributes"];
        }
    }
    @Html.DropDownListFor(m => m, selectList, htmlAttributes)
