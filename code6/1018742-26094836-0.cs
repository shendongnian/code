    Collection scenarios = element.Scenarios
                                  .Cast<Scenario>()
                                  .OrderBy(c => c.type == "Basic Path" ? 0 : 1);
    
    foreach (Scenario sc in scenarios)
    {
        //Start with the scenario that has "Basic Path" type
    }
