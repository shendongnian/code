    public class MissingInterfaceMemberImplementationVisitor : DepthFirstAstVisitor
    {
        private readonly CSharpAstResolver _resolver;
        public bool IsInterfaceMemberMissing { get; private set; }
        public MissingInterfaceMemberImplementationVisitor(CSharpAstResolver resolver)
        {
            _resolver = resolver;
            IsInterfaceMemberMissing = false;
        }
        public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            if (typeDeclaration.ClassType == ClassType.Interface || typeDeclaration.ClassType == ClassType.Enum)
                return;
            base.VisitTypeDeclaration(typeDeclaration);
            var rr = _resolver.Resolve(typeDeclaration);
            if (rr.IsError)
                return;
            foreach (var baseType in typeDeclaration.BaseTypes)
            {
                var bt = _resolver.Resolve(baseType);
                if (bt.IsError || bt.Type.Kind != TypeKind.Interface)
                    continue;
                bool interfaceMissing;
                var toImplement = ImplementInterfaceAction.CollectMembersToImplement(rr.Type.GetDefinition(), bt.Type, false, out interfaceMissing);
                if (toImplement.Count == 0)
                    continue;
                IsInterfaceMemberMissing = true;
            }
        }
    }
