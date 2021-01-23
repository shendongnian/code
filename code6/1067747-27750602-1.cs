    static class Extensions
    {
        public static IEnumerable<dynamic> ExecuteSQL (this DataContext dc, string sql)
        {
            var cx = new SqlConnection (dc.Connection.ConnectionString);
            cx.Open();
            return new SqlCommand (sql, cx).ExecuteReader (CommandBehavior.CloseConnection).Cast<IDataRecord>().Select (r => new DynamicDataRecord (r));
        }
    }
    
    class DynamicDataRecord : System.Dynamic.DynamicObject
    {
        readonly IDataRecord _row;
        public DynamicDataRecord (IDataRecord row) { _row = row; }
    
        public override bool TryConvert (System.Dynamic.ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof (IDataRecord))
            {
                result = _row;
                return true;
            }
            return base.TryConvert (binder, out result);
        }
    
        public override bool TryInvokeMember (System.Dynamic.InvokeMemberBinder binder, object [] args, out object result)
        {
            if (binder.Name == "Dump")
            {
                if (args.Length == 0)
                    _row.Dump ();
                else if (args.Length == 1 && args [0] is int)
                    _row.Dump ((int)args [0]);
                else if (args.Length == 1 && args [0] is string)
                    _row.Dump ((string)args [0]);
                else if (args.Length == 2)
                    _row.Dump (args [0] as string, args [1] as int?);
                else
                    _row.Dump ();
                result = _row;
                return true;
            }
            return base.TryInvokeMember (binder, args, out result);
        }
    
        public override bool TryGetMember (System.Dynamic.GetMemberBinder binder, out object result)
        {
            result = _row [binder.Name];
            if (result is DBNull) result = null;
            return true;
        }
    
        public override bool TryGetIndex (System.Dynamic.GetIndexBinder binder, object [] indexes, out object result)
        {
            if (indexes.Length == 1)
            {
                result = _row [int.Parse (indexes [0].ToString ())];
                return true;
            }
            return base.TryGetIndex (binder, indexes, out result);
        }
    
        public override IEnumerable<string> GetDynamicMemberNames ()
        {
            return Enumerable.Range (0, _row.FieldCount).Select (i => _row.GetName (i));
        }
    }
