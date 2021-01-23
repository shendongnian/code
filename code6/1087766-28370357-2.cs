    @model ClubViewModel
    
    @for (int meetingDay = 0; meetingDay < Model.MeetingDays.Count; meetingDay++)
    {
        @* Get the current day of week *@
        var dayOfWeek = Enum.GetName(typeof (DayOfWeek), meetingDay);
        
        <label>@dayOfWeek Start</label>
        @Html.TextBoxFor(m => Model.MeetingDays[meetingDay].From)
        <label>@dayOfWeek Finish</label>
        @Html.TextBoxFor(m => Model.MeetingDays[meetingDay].To)
    }
