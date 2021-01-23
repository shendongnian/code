    public static System.Collections.Generic.List<Type> GetTypesImplementingInterface(string interfaceTypeName, string assembliesNameStartWith)
        {
            var returnTypes = new System.Collections.Generic.List<Type>();
            var list = BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(referencedAssembly => referencedAssembly.FullName.StartsWith(assembliesNameStartWith, StringComparison.InvariantCultureIgnoreCase)).ToList();
            try
            {
                returnTypes.AddRange(
                    from ass in list
                    from t in ass.GetTypes()
                    where (TypeImplementsInterface(t, interfaceTypeName))
                    select t
                );
            }
            catch (Exception ex)
            {
                Trace.TraceWarning("GetTypesImplementingInterface:{0}:interfaceTypeName:{1}:assembliesNameStartWith:{2}",
                                   ex.ToString(), interfaceTypeName, assembliesNameStartWith);
                returnTypes = new System.Collections.Generic.List<Type>();
            }
            return returnTypes;
        }
        private static bool TypeImplementsInterface(Type theType, string interfaceName)
        {
            Type interFaceType = theType.GetInterface(interfaceName, true);
            return (interFaceType != null);
        }
