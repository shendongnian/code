        public void FillDbObjectList<T>(out List<T> list, string tableName) where T : CommonUtilities.DbObjectTableBase
        {
            list = new List<T>();
            ADODB.Recordset rcd;
            this.FillRecordset(EDbRecordSource.Table, tableName, out rcd);
            while (!rcd.EOF)
            {
                object[] paramArray = this.FillActivatorParameterArray(rcd);
                list.Add((T)Activator.CreateInstance(typeof(T), paramArray));
                rcd.MoveNext();
            }
            this.TryCloseRecordset(rcd);
        }
