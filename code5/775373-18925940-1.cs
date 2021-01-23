      Html.Kendo().Scheduler<Kendo.Mvc.Examples.Models.Scheduler.Screening>()
            .Name("scheduler")
            .Date(new DateTime(2013, 6, 13))
            .StartTime(new DateTime(2013, 6, 13, 10, 00, 00))
            .EndTime(new DateTime(2013, 6, 13, 23, 00, 00))
            .Height(600)
            .EventTemplate(
            "<div class='customAllDayTemplate'>" +
                "<img src='" + Url.Content("~/Content/web/scheduler/") + "#= Image #' />" +
                "<p>" + 
                    "#= kendo.toString(start, 'hh:mm') # - #= kendo.toString(end, 'hh:mm') #" + 
                "</p>" + 
                "<h3>#= title #</h3>" +
                "<a href='#= Imdb #'>Movie in IMDB</a>" +
            "</div>")
            .Views(views =>
            {
            views.DayView();
            views.AgendaView();
            })
            .BindTo(Model)
            )
