    public class ODataExtendedConventionModelBuilder : ODataConventionModelBuilder
        
        public override ComplexTypeConfiguration AddComplexType(Type type)
        {
            var x = base.AddComplexType(type);
            x.Namespace = Namespace;
            return x;
        }
        public override EntityTypeConfiguration AddEntityType(Type type)
        {
            var x = base.AddEntityType(type);
            x.Namespace = Namespace;
            return x;
        }
        public override EnumTypeConfiguration AddEnumType(Type type)
        {
            var x = base.AddEnumType(type);
            x.Namespace = Namespace;
            return x;
        }
        public override void AddProcedure(ProcedureConfiguration procedure)
        {
            procedure.Namespace = Namespace;
            base.AddProcedure(procedure);
        }
    }
