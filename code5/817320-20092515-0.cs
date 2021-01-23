            var someType = Type.GetType("MyProject.Employee");
            var genericType = typeof(Convert<>).MakeGenericType(new[] { someType });
            var instance = Activator.CreateInstance(genericType);
    
            string instanceType = instance.GetType().FullName;
    
            MethodInfo methodInfo = Type.GetType(instanceType).GetMethod("Translate");
            genericType.InvokeMember(methodInfo.Name, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, instance, new object[] { lstEmp, "Name", "City" });
