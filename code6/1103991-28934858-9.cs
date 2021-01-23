    public class StudentViewModel
    {
        public string TeamName{ get; set; }
        public int Percentage { get; set; }
    }
    @(Html.Kendo().Chart<StudentViewModel>()
        .Name("chart2")
        .DataSource(ds => ds.Read("GetTeamData", "Home"))
        .Series(series => series.Pie(m => m.Percentage, model => model.TeamName))
    )
