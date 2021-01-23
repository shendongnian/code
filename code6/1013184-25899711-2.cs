    ...
    @Html.HiddenFor(model => model.ID);
    @Html.EditorFor(model => model.ReportDate);
    @for (var i; i < Model.LineItems.Count; i++)
    {
        @html.HiddenFor(e => Model.LineItems[i].ID);
        @html.EditorFor(e => Model.LineItems[i].ItemDescription);
    }
    ...
