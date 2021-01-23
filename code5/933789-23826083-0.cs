    [Table("Step")]
    public class Step
    {
        [PrimaryKey, AutoIncrement]
        public int StepId { get; set; }
        [ForeignKey(typeof(WorkFlow))]
        public int WorkFlowId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [ManyToOne]
        public Workflow Workflow { get; set; }
    }
