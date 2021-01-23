	private static HashSet<Type> m_PassableTypes; // 
	static SynthesisExtensions() { // 
        m_PassableTypes = new HashSet<Type>();
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
            foreach (Type type in assembly.GetTypes()) {
                if (type.IsValueType || type == typeof (string) || type.Module.Name == "FSharp.Core.dll" ||
                    type.IsDefined(typeof (MessageAttribute), false)) {
                    m_PassableTypes.Add(type);
                }
            }
        }
	}
