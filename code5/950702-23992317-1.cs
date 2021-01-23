    public class FailPipelineModule : HubPipelineModule
    {
        public override Func<IHubIncomingInvokerContext, Task<object>> BuildIncoming(Func<IHubIncomingInvokerContext, Task<object>> invoke)
        {
            return base.BuildIncoming(context =>
            {
                var r = (bool)(invoke(context)).Result;
                if (context.MethodDescriptor.Attributes.Any(a => typeof(FailAttribute) == a.GetType()) && !r)
                    throw new ApplicationException("false");
                return Task.FromResult((object)r);
            });
        }
    }
