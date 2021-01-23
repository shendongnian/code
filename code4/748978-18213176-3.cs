    private static void FindInitialBaseflow<T>(Fluent<T> fluent) 
        where T : Flow
    {
        var linqFluent = fluent;
        var flows = linqFluent.FlowCollection.Where(
                    flow =>
                    flow.Time >= SOME_DATE &&
                    flow.Time < SOME_OTHER_DATE);
        var initialBaseflow = flows.Average(flow => flow.Value);
        fluent.InitialBaseflow = Math.Round(initialBaseflow, 5);
    }
