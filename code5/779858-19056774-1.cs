    @foreach (DayOfWeek item in Enum.GetValues(typeof(DayOfWeek)))
    {
        if (0 < item && (item <= DayOfWeek.Friday || item == DayOfWeek.Saturday))
        {
            @Html.Label("DayOfWeek", item.ToString())
            @Html.CheckBox("DayOfWeek", (Model.DayOfWeek.HasFlag(item)), new { value = item })
        }
    }
