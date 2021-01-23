    PlanVersion planVersion = null;
    
    // the most INNER SELECT
    var maxSubquery = QueryOver.Of<PlanVersion>()
       .SelectList(l => l
        .SelectGroup(item => item.ParentPlan.Id)
        .SelectMax(item => item.ActiveFromDate)
        )
        // WHERE Clause
       .Where(item => item.ParentPlan.Id == planVersion.ParentPlan.Id)
       // HAVING Clause
       .Where(Restrictions.EqProperty(
          Projections.Max<PlanVersion>(item => item.ActiveFromDate),
          Projections.Property(() => planVersion.ActiveFromDate)
        ));
    
    // the middle SELECT
    var successSubquery = QueryOver.Of<PlanVersion>(() => planVersion )
        // the Plan ID
        .Select(pv => pv.ParentPlan.Id)
        .WithSubquery
        .WhereExists(maxSubquery)
        ;
