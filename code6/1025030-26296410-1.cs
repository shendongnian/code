    using System.Reflection;
    ...
    System.Type thisType = this.GetType();
    System.Reflection.TypeInfo thisTypeInfo = thisType.GetTypeInfo();
    MethodInfo method = thisTypeInfo.GetDeclaredMethod(functionName);
    object[] parameters = {this, null};
    method.Invoke(this, parameters);
