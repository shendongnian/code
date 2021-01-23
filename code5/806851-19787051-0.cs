    ...
    @foreach (var item in items)
    {
        <span data-refered-type="@item.Item.Value">
            @if (item.Type.IsSubclassOf(typeof(AFieldFormula)))
            {
                var newModel = item.Item.Selected ? Model : Activator.CreateInstance(item.Type);
                @Html.Partial("~/Views/MemberField/EditorTemplates/AFieldFormula_" + item.Type.Name + ".cshtml", newModel, new ViewDataDictionary { { "vb", ViewBag }})
            }
        </span>
    }
