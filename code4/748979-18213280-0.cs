    private static void FindInitialBaseflow(Fluent fluent)
        {
            var linqFluent = fluent;
    
            var flows = linqFluent.FlowCollection.ToList().FindAll(
                        flow =>
                        flow.Time >= SOME_DATE &&
                        flow.Time < SOME_OTHER_DATE);
            var initialBaseflow = flows.Average(flow => flow.Value);
            fluent.InitialBaseflow = Math.Round(initialBaseflow, 5);  
        }
