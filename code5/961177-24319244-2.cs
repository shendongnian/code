    public class MustBeCreatorEditorPublisherAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute() { ErrorMessage = "You must be a creator, editor or publisher"; }
        public override bool IsValid(object value)
        {
            using (Role role = value as Role)
            {
                return (role.IsCreator || role.IsEditor || role.IsPublisher);
            }
            return base.IsValid(value);
        }
    }
