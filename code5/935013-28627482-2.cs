    public class AdviceIdTypeHandler : SqlMapper.TypeHandler<AdviceId>
    {
        public override void SetValue(IDbDataParameter parameter, AdviceId value)
        {
            parameter.Value = value.ToString();
        }
        public override AdviceId Parse(object value)
        {
            return new AdviceId((string)value);
        }
    }
    SqlMapper.AddTypeHandler(new AdviceIdTypeHandler());
