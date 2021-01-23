    public class CustomTypeProvider: IDynamicLinkCustomTypeProvider
    {
        public HashSet<Type> GetCustomTypes()
        {
            HashSet<Type> types = new HashSet<Type>();
            types.Add(typeof(Patient));
            types.Add(typeof(RiskFactorResult));
            types.Add(typeof(PatientLabResult));
            types.Add(typeof(PatientVital));
            return types;
        }
    }
