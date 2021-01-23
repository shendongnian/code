    public override int ExecuteNonQuery()
        {
            int num;
            IntPtr ptr;
            OleDbConnection.ExecutePermission.Demand();
            Bid.ScopeEnter(out ptr, "<oledb.OleDbCommand.ExecuteNonQuery|API> %d#\n", this.ObjectID);
            try
            {
                this._executeQuery = false;
                this.ExecuteReaderInternal(CommandBehavior.Default, "ExecuteNonQuery");
                num = ADP.IntPtrToInt32(this._recordsAffected);
            }
            finally
            {
                Bid.ScopeLeave(ref ptr);
            }
            return num;
        }
