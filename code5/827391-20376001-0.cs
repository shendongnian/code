    @if (item.StartDate.Date != DateTime.Today)
    {
        <span class="yellow"> @Html.DisplayFor(modelitem=>item.StartDate) </span>
    }
    else
    {
        <span class="yellow"> Today </span>
    }
