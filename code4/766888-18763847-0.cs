    [OracleCustomTypeMapping("GUIDARRAY")]
    public class GuidArrayFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        public IOracleCustomType CreateObject()
        {
            return new GuidArray();
        }
    
        // IOracleArrayTypeFactory Inteface
        public Array CreateArray(int numElems)
        {
            return new Byte[numElems][];
        }
    
        public Array CreateStatusArray(int numElems)
        {
            // CreateStatusArray may return null if null status information 
            // is not required.
            return new OracleUdtStatus[numElems];
        }
    }
    
    
-
        // See %ODAC_HOME%\ODACsamples\odp.net\4\UDT
        public class GuidArray : IOracleCustomType, INullable
        {
            [OracleArrayMapping]
            public Byte[][] Array;
    
            private OracleUdtStatus[] m_statusArray;
            public OracleUdtStatus[] StatusArray
            {
                get
                {
                    return m_statusArray;
                }
                set
                {
                    m_statusArray = value;
                }
            }
    
            private bool m_bIsNull;
    
            public bool IsNull
            {
                get
                {
                    return m_bIsNull;
                }
            }
    
            public static GuidArray Null
            {
                get
                {
                    GuidArray obj = new GuidArray();
                    obj.m_bIsNull = true;
                    return obj;
                }
            }
    
            public void ToCustomObject(OracleConnection con, IntPtr pUdt)
            {
                object objectStatusArray = null;
                Array = (Byte[][])OracleUdt.GetValue(con, pUdt, 0, out objectStatusArray);
                m_statusArray = (OracleUdtStatus[])objectStatusArray;
            }
    
            public void FromCustomObject(OracleConnection con, IntPtr pUdt)
            {
                OracleUdt.SetValue(con, pUdt, 0, Array, m_statusArray);
            }
    
            public override string ToString()
            {
                if (m_bIsNull)
                    return "GuidArray.Null";
    
                string rtnstr = String.Empty;
                if (m_statusArray[0] == OracleUdtStatus.Null)
                    rtnstr = "NULL";
                else
                    rtnstr = Array.GetValue(0).ToString();
                for (int i = 1; i < m_statusArray.Length; i++)
                {
                    if (m_statusArray[i] == OracleUdtStatus.Null)
                        rtnstr += "," + "NULL";
                    else
                        rtnstr += "," + Array.GetValue(i);
                }
                return "GuidArray(" + rtnstr + ")";
                
            }
        }
