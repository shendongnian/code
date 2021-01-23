    public interface IWorkflowValidator { }
    
    public interface IWorkflowValidator<T> : IWorkflowValidator
        where T : IPersistent, IStateful, new() { }
    
    public class WorkflowService
    {
        public WorkflowService(ControllerAccess controllerAccess, IValidationDictionary validatonDictionary, IWorkflowValidator workflowValidator) { }
    }
