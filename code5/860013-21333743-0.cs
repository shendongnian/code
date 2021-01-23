    @using Kendo.Mvc.UI;
    @model List<Optic.Models.Scheduling.Events>
    
    @(Html.Kendo().Scheduler<Optic.Models.Scheduling.Events>()
            .Name("scheduler")
            .Date(new DateTime(2014, 1, 22))
            .StartTime(new DateTime(2013, 6, 13, 07, 00, 00))
            .EndTime(new DateTime(2013, 6, 13, 23, 00, 00))
            .Editable(false)
            .Height(600)
            .Views(views =>
            {
                views.DayView();
                views.WeekView(week => week.Selected(true));
                views.MonthView();
                views.AgendaView();
            })
            .DataSource(d => d
            .Model(m => m.Id(f => f.Id)) 
            .Read("GetAll", "Scheduling")       
            )
            
            .BindTo(Model)
    )
