    public class GuidField : Field<Guid>
    {
        public override void Serialize(StringWriter sw_)//Assume we have made base class method virtual
        {
            value.Serialize(sw_);
        }
    }
