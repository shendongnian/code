    public class TheProjects
        {
            public int Id { get; set; }
            public string ProjectName { get; set; }
            public short PhaseCount { get; set; }
            public string ProjectOwner { get; set; }
            public byte PriorityValue { get; set; } /* check if you really need this */
            public PriorityForProject Priority { get; set; }
    
        }
