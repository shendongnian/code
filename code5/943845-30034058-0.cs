        public static class ConfigFactory<T> where T : class {
        static T cachedImplInstance;
        public static T BuildConfigGroupWithReflection() {
            if (cachedImplInstance == null) {
                Type interfaceType = typeof(T);
                MethodInfo setupGetMethodInfo = typeof(Mock<T>).GetMethod("SetupGet");
                Mock<T> interfaceMock = new Mock<T>();
                IDictionary<Type, MethodInfo> genericSetupGetMethodInfos = new Dictionary<Type, MethodInfo>();
                IDictionary<Type, MethodInfo> specificReturnsMethodInfos = new Dictionary<Type, MethodInfo>();
                if (setupGetMethodInfo != null)
                    foreach (PropertyInfo interfaceProperty in interfaceType.GetProperties()) {
                        string propertyName = interfaceProperty.Name;
                        Type propertyType = interfaceProperty.PropertyType;
                        ParameterExpression parameter = Expression.Parameter(interfaceType);
                        MemberExpression body = Expression.Property(parameter, propertyName);
                        var lambdaExpression = Expression.Lambda(body, parameter);
                        MethodInfo specificSetupGetMethodInfo =
                            genericSetupGetMethodInfos.ContainsKey(propertyType) ?
                            genericSetupGetMethodInfos[propertyType] :
                            genericSetupGetMethodInfos[propertyType] = setupGetMethodInfo.MakeGenericMethod(propertyType);
                        object setupResult = specificSetupGetMethodInfo.Invoke(interfaceMock, new[] { lambdaExpression });
                        MethodInfo returnsMethodInfo = 
                            specificReturnsMethodInfos.ContainsKey(propertyType) ?
                            specificReturnsMethodInfos[propertyType] :
                            specificReturnsMethodInfos[propertyType] = setupResult.GetType().GetMethod("Returns", new[] { propertyType });
                        if (returnsMethodInfo != null)
                            returnsMethodInfo.Invoke(setupResult, new[] { Settings.Default[propertyName] });
                    }                
                cachedImplInstance = interfaceMock.Object;
            }
            return cachedImplInstance;
        }
    }
