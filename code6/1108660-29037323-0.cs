    class TypeDTO {
        public string AssemblyName;
        public string ClassName;
    
        public static TypeDTO FromType(Type type) {
            return new TypeDTO() {
                AssemblyName = type.Assembly.FullName,
                ClassName = type.FullName
            };
        }
    
        public Type ToType() {
            return ToType(AppDomain.CurrentDomain);
        }
    
        public Type ToType(AppDomain domain) {
            Assembly assembly = domain.GetAssemblies().Where(t => t.FullName == AssemblyName).Single();
            return assembly.GetType(ClassName);
        }
    }
    
    class MethodSignatureDTO {
        public TypeDTO DeclaringType;
        public string MethodName;
        public TypeDTO[] ParameterTypes;
    
        public static MethodSignatureDTO FromMethod(MethodInfo method) {
            return new MethodSignatureDTO() {
                DeclaringType = TypeDTO.FromType(method.DeclaringType),
                MethodName = method.Name,
                ParameterTypes = method.GetParameters().Select(t => TypeDTO.FromType(t.ParameterType)).ToArray()
            };
        }
        public MethodInfo ToMethod() {
            return ToMethod(AppDomain.CurrentDomain);
        }
    
        public MethodInfo ToMethod(AppDomain domain) {
            Type[] parameterTypes = ParameterTypes.Select(t => t.ToType(domain)).ToArray();
            return DeclaringType.ToType(domain).GetMethod(MethodName, parameterTypes);
        }
    }
    
    class MethodCallDTO {
        public MethodSignatureDTO Method;
        public object Instance;
        public object[] Arguments;
    
        public object Invoke() {
            return Invoke(AppDomain.CurrentDomain);
        }
    
        public object Invoke(AppDomain domain) {
            return Method.ToMethod(domain).Invoke(Instance, Arguments);
        }
    }
