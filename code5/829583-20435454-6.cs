    StringBuilder source = new StringBuilder();
    source.AppendLine("using System;");
    source.AppendLine("using System.ServiceModel;");
    source.AppendLine("[ServiceContract]");
    source.AppendLine("public class DynamicService {");
    // Here for each MethodInfo from list generate a method source like
    foreach (var method in methods)
    {
        if (method.ReturnType == typeof(void))
            continue;
        string parameters = string.Join(", ", method.GetParameters().Select(pi => string.Format("{0} {1}", pi.ParameterType.Name, pi.Name)));
        string arguments = string.Join(", ", method.GetParameters().Select(pi => pi.Name));
        source.AppendFormat("[OperationContract]");
        source.AppendFormat("public {0} {1}({2})", method.ReturnType.Name, method.Name, parameters);
        source.AppendFormat("{{   return ConsoleApplication.Helpers.{0}({1}); }}", method.Name, arguments);
    }
    source.AppendLine("}");
