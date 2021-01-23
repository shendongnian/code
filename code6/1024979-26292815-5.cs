    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    
    public partial class UserDefinedFunctions
    {    
        [SqlFunction()]
        public static SqlBinary bitwiseAnd128Bit(SqlBinary lhs, SqlBinary rhs)
        {
            My128BitValue v1 = My128BitValue.FromByteArray((byte[])lhs); //explicit conversion
            My128BitValue v2 = My128BitValue.FromByteArray((byte[])rhs);
            My128BitValue result = v1 & v2;
            return result.ToByteArray(); //implicit conversion
        }
    }
