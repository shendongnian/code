    public class CSharpWorkflowServiceHostFactory : WorkflowServiceHostFactory
    {
        protected override WorkflowServiceHost CreateWorkflowServiceHost(WorkflowService service, Uri[] baseAddresses)
        {
            CompileExpressions(service.Body);
            return base.CreateWorkflowServiceHost(service, baseAddresses);
        }
    }
