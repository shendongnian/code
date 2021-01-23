    public class CustomBodyModelValidator : DefaultBodyModelValidator
    {
        public override bool ShouldValidateType(Type type)
        {
            return type!= typeof(DbGeography) && base.ShouldValidateType(type);
        }
    }
