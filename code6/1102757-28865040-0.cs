    public class Leads
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string TaskName { get; set; }
        //The second table
        public virtual IList<Workflow> Workflows { get; set; }
    }
    public class LeadsClassMap : ClassMap<Leads>
    {
        public LeadsClassMap()
        {
            Table("Leads");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.TaskName);
            //My attempt to join the tables
            HasMany(x => x.Workflows)
                .KeyColumn("LeadId")
                .Cascade.All();
        }
    }
    public class Workflow
    {
        public virtual int Id { get; set; }
        public virtual Leads Lead { get; set; }
        public virtual bool PreviouslySubmitted { get; set; }
        public virtual Guid SubmittedBy { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int WorkflowStep { get; set; }
    }
    public class WorkflowClassMap : ClassMap<Workflow>
    {
        public WorkflowClassMap()
        {
            Table("Workflow");
            Id(x => x.Id).GeneratedBy.Native();
            References(x => x.Lead, "LeadId");
            Map(x => x.PreviouslySubmitted);
            Map(x => x.SubmittedBy);
            Map(x => x.Modified);
            Map(x => x.WorkflowStep);
        }
    }
