    public class CustomBodyModelProvider : DefaultBodyModelValidator
    {
        public override bool ShouldValidateType(Type type)
        {
            return type!= typeof(DbGeography) && base.ShouldValidateType(type);
        }
    }
