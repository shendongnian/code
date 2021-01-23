    public EvaluationHeadMap()
    {
        Id(x => x.EvaluationHeadID).GeneratedBy.Identity();
        Map(x => x.EmployeeID).Not.Insert().Not.Update();
        Map(x => x.ManagerID).Not.Insert().Not.Update();
        Map(x => x.SupervisorID).Not.Insert().Not.Update();
    
    //other properties
    
        References(x => x.Employee).Column("EmployeeID").Cascade.None();
    
        // Instead of this
        // References(x => x.Manager).Column("EmployeeID").Cascade.None(); ;
        // References(x => x.Supervisor).Column("EmployeeID").Cascade.None();
    
        // use this
        References(x => x.Manager).Column("ManagerID").Cascade.None(); ;
        References(x => x.Supervisor).Column("SupervisorID").Cascade.None();
    }
