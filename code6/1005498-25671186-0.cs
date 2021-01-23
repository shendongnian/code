    public class AddVersionWorkflowAction
    {
        public void Process(WorkflowPipelineArgs args)
        {
            // TODO: check for nulls, assertions, etc.
    
            args.DataItem.Versions.AddVersion();
        }
    }
