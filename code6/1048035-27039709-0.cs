    public interface IWorkflowValidator<T> where T : IPersistent, IStateful, new() { }
    
    public class WorkflowService<T> where T: IPersistent, IStateful, new()
    {
        public WorkflowService(ControllerAccess controllerAccess, IValidationDictionary validatonDictionary, IWorkflowValidator<T> workflowValidator)
        { }
    }
