    public class InheritedRoutePrefixDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
        {
            var sb = new StringBuilder(base.GetRoutePrefix(controllerDescriptor));
            var baseType = controllerDescriptor.ControllerType.BaseType;
            for (var t = baseType; typeof(ApiController).IsAssignableFrom(t); t = t.BaseType)
            {
                var a = (t as MemberInfo).GetCustomAttribute<RoutePrefixAttribute>(false);
                if (a != null)
                {
                    sb.Insert(0, $"{a.Prefix}{(sb.Length > 0 ? "/": "")}");
                }
            }
            return sb.ToString();
        }
    }
