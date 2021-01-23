    //extention method for converting DateTime to normalized double
    public static double ToMinutes(this DateTime value)
    {
       return (value-new DateTime(2014, 12, 3)).TotalMinutes;
    }
    
    var a1_start = new DateTime(2014, 12, 4).ToMinutes();
    var a1_finish = new DateTime(2014, 12, 4, 2, 0, 0).ToMinutes();
    var a2_start = new DateTime(2014, 12, 4, 4, 0, 0).ToMinutes();
    var a2_finish = new DateTime(2014, 12, 4, 6, 0, 0).ToMinutes();
    var b1_start = new DateTime(2014, 12, 4,1,0,0).ToMinutes();
    var b1_finish = new DateTime(2014, 12, 4, 1, 55, 0).ToMinutes();
    var B2_start = new DateTime(2014, 12, 4, 5, 0, 0).ToMinutes();
    var B2_finish = new DateTime(2014, 12, 4, 6, 0, 0).ToMinutes();
    
    var context = SolverContext.GetContext();
    var model = context.CreateModel();
    var a_OperationTime = 60;
    var b_OperationTime = 60;
    var tolerance = 10;
           
    //Decision
    Decision A_StartTime = new Decision(Domain.IntegerNonnegative,"A_StartTime");
    model.AddDecision(A_StartTime);
    Decision B_StartTime = new Decision(Domain.IntegerNonnegative,"B_StartTime");
    model.AddDecision(B_StartTime);
    //Constraints
    model.AddConstraint("A_TimeLimitations",
                            ((a1_start <= A_StartTime <= a1_finish) & 
                             (a1_start - 60 <= A_StartTime + 60 <= a1_finish)) |
                            ((a2_start <= A_StartTime <= a2_finish) & 
                             (a2_start - 60 <= A_StartTime + 60 <= a2_finish)));
    model.AddConstraint("B_TimeLimitations",
                           ((b1_start <= B_StartTime <= b1_finish) & 
                            ((b1_start - 60 <= B_StartTime + 60 <= b1_finish))) |
                           ((B2_start <= B_StartTime <= B2_finish) & 
                            (B2_start - 60 <= B_StartTime + 60 <= B2_finish)));
    model.AddConstraint("B_ContiguousLimitations",
                              B_StartTime - (A_StartTime + 60) <= tolerance);
    model.AddConstraint("B_GreaterThan_A",
                         B_StartTime >= A_StartTime + 60);
    //Goal
    A_StartTime = model.Decisions.First(x => x.Name == "A_StartTime");
    B_StartTime = model.Decisions.First(x => x.Name == "B_StartTime");
    model.AddGoals("OrderDuration", GoalKind.Minimize, B_StartTime - A_StartTime);
    //Solve
    var directive = new ConstraintProgrammingDirective();
    var solution = context.Solve(directive);
