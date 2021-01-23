    @for (var i = 0; i < lst.Count; i++)
    {
        ...
        @Html.CheckBoxFor(x => lst[i].IsCreate)
        @Html.CheckBoxFor(x => lst[i].IsView)
        @Html.CheckBoxFor(x => lst[i].IsDelete)
        ...
    }
