    public class InvocationRenderer : IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            var invocation = (IInvocation)obj;
            var builder = new StringBuilder();
            builder.AppendFormat(
                "Invoking Method: {0} --> '{1}' with parameters (", 
                invocation.Method.DeclaringType != null 
                   ? invocation.Method.DeclaringType.FullName : "{Unknown Type}",
                invocation.Method);
            var parameters = invocation.Method
                .GetParameters()
                .Zip(invocation.Arguments, (p, a) => new { Parameter = p, Argument = a })
                .ToArray();
            var index = 0;
            foreach (var parameter in parameters)
            {
                builder.AppendFormat(
                    "{0}: {1}", 
                    parameter.Parameter.Name, 
                    rendererMap.FindAndRender(parameter.Argument));
                if (++index < parameters.Length)
                {
                    builder.Append(", ");
                }
            }
            builder.Append(")");
            writer.Write(builder.ToString());
        }
    }
