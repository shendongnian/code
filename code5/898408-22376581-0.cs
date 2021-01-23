    public class LoggingInterceptor: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            using (Tracer t = new Tracer(string.Format("{0}.{1}", invocation.TargetType.Name, invocation.Method.Name)))
            {
                StringBuilder sb = new StringBuilder(100);
                sb.AppendFormat("IN (", invocation.TargetType.Name, invocation.Method.Name);
                sb.Append(string.Join(", ", invocation.Arguments.Select(a => a == null ? "null" : DumpObject(a)).ToArray()));
                sb.Append(")");
                t.Verbose(sb.ToString());
    
                invocation.Proceed();
    
                sb = new StringBuilder(100);
                sb.AppendFormat("OUT {0}", invocation.ReturnValue != null ? DumpObject(invocation.ReturnValue) : "void");
                t.Verbose(sb.ToString());
            }
        }
    
        private string DumpObject(object argument)
        {
            // serialize object
        }
    }
