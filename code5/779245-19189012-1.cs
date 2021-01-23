    public class ProjectNumberModel : BaseModel
    {
        public ProjectPhaseModel ProjectPhase { get; set; }
        public string Number { get; set; }
        public bool Active { get; set; }
        public int ProjectId { get; set; }
        public ProjectNumberModel()
        {
            ProjectPhase = new ProjectPhaseModel();
        }
    }
    public class ProjectPhaseModel
    {
        public int ProjectPhaseId { get; set; }
        public string ProjectPhase { get; set; }
    }
