        private object[] FillActivatorParameterArray(ADODB.Recordset rcd)
        {
            object[] paramArray = new object[rcd.Fields.Count];
            for (int i = 0; i < rcd.Fields.Count; i++)
            {
                if (rcd.Fields[i].Value == DBNull.Value)
                {
                    paramArray[i] = null;
                }
                else
                {
                    paramArray[i] = rcd.Fields[i].Value;
                }
            }
            return paramArray;
        }
