        private static bool IsInterfaceImplementation(PropertyInfo p, InterfaceMapping interfaceMap)
        {
            var getterIndex = Array.IndexOf(interfaceMap.TargetMethods, p.GetGetMethod());
            var setterIndex = Array.IndexOf(interfaceMap.TargetMethods, p.GetSetMethod());
            return getterIndex != -1 || setterIndex != -1;
        }
        private static PropertyInfo[] GetPropertiesExcludeInterfaceImplementation(Type type, Type interfaceType)
        {
            var interfaceMap = type.GetInterfaceMap(interfaceType);
            return type
                .GetProperties()
                .Where(p => !IsInterfaceImplementation(p, interfaceMap))
                .ToArray();
        }
