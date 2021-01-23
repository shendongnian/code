    static string GetMethodContextName() {
        var name = new StackTrace().GetFrame(1).GetMethod().GetMethodContextName();
    }
    static string GetMethodContextName(this MethodBase method) {
        if (method.DeclaringType.GetInterfaces().Any(i => i == typeof(IAsyncStateMachine))) {
            var generatedType = method.DeclaringType;
            var originalType = generatedType.DeclaringType;
            var foundMethod = originalType.GetMethods(Instance | Static | Public | NonPublic | DeclaredOnly)
                .Single(m => m.GetCustomAttribute<AsyncStateMachineAttribute>()?.StateMachineType == generatedType);
            return foundMethod.DeclaringType.Name + "." + foundMethod.Name;
        } else {
            return method.DeclaringType.Name + "." + method.Name;
        }
    }
