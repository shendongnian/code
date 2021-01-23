    public class OracleGuidHandler : SqlMapper.TypeHandler<OracleGuid>
    {
        public override OracleGuid Parse(object value)
        {
            return new OracleGuid((byte[]) value);
        }
        public override void SetValue(System.Data.IDbDataParameter parameter, OracleGuid value)
        {
            parameter.Value = value.InternalGuid.ToByteArray();
        }
    }
