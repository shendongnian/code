            var con = new OleDbConnection();
            var cmd = new OleDbCommand(str, con);
            var dr = cmd.ExecuteReader();
            var res = string.Empty;
            if (dr.Read())
            {
                object[] t = new Object[dr.FieldCount];
                if (dr.GetValues(t)>0)
                {
                     res = String.Join(";", (from el in t select el as string).Where(x => x!=null).ToArray());
                }
            }
            return res;
