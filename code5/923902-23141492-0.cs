    public class CommunicationAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var communicationObject = args.Instance as CommunicationObject;
            communicationObject.Open();
            args.FlowBehavior = FlowBehavior.Continue;
        }
        public override void OnException(MethodExecutionArgs args)
        {
            _logger.log(string.Format("Exception {0} has occured on method {1}", args.Exception, args.Method.Name));
        }
    }
