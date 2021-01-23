    public class ProjectDetailedOverviewDto
    {
        public int PropertyPlanId { get; set; }
        public int ProjectId { get; set; }
        public string DetailedOverview { get; set; }
    }
    public JsonNetResult SaveDetailedOverview(ProjectDetailedOverviewDto detailedOverview) { ... }
