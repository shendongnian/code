    [Serializable]
    public class XmlLogAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            ILog log = LogManager.GetLogger(args.Method.DeclaringType);
            if (log.IsDebugEnabled)
            {
                log.DebugFormat("<Method name=\"{0}\">", args.Method.Name);
                log.Debug("<Params>");
                foreach (object methodArgument in args.Arguments)
                {
                    if (methodArgument == null)
                    {
                        log.Debug("<null/>");
                    }
                    else
                    {
                        log.DebugFormat("<{0}>{1}</{0}>", methodArgument.GetType(), methodArgument);
                    }
                }
                log.Debug("</Params>");
            }
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ILog log = LogManager.GetLogger(args.Method.DeclaringType);
            log.Debug("</Method>");
        }
    }
