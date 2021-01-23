    [OracleCustomTypeMapping("TAB_VARCHAR2_250")]
    public class StringTableFactory : TableFactoryTemplate<StringTable>
    {
        public override System.Array CreateStatusArray(int length)
        {
            return new OracleUdtStatus[length];
        }
    }
