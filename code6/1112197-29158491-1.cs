    @model IEnumerable<ReportSystem.Models.TimeReports>
    <table>
      ....
    </table>
    @Html.ActionLink("Previous Week", "Index", "TimeReports", new { ID = ViewBag.PreviousWeek })
    // Assume you don't want to navigate to a future week
    @if (ViewBag.NextWeek < 0)
    {
      @Html.ActionLink("Next Week", "Index", "TimeReports" new { ID = ViewBag.NextWeek })
    }
