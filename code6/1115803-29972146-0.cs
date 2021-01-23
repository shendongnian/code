    		public static OrmLiteSPStatement CallMyStoredProcTVP(this IDbConnection db, HashSet<int> userids)
		{
			// need to create a datatable to pass as a parameter to your tvp SP
			DataTable dataTableUserIds = new DataTable();
			dataTableUserIds.Columns.Add("Value", typeof(Int32));
			foreach (int id in userids)
			{
				DataRow ro = dataTableUserIds.NewRow();
				ro[0] = id;
				dataTableUserIds.Rows.Add(ro);
			}
			// create db command
			var dbCmd = (DbCommand)OrmLiteConfig.ExecFilter.CreateCommand(db).ToDbCommand();
			// set name of SP
			dbCmd.CommandText = "MyStoredProcTVP";
			dbCmd.CommandType = CommandType.StoredProcedure;
			// add new parameter but I leave off the Type
			dbCmd.Parameters.Add(CreateNewParameter(dbCmd, "UserIDs", dataTableUserIds, ParameterDirection.Input));
			return new OrmLiteSPStatement(db, dbCmd);
		}
		private static DbParameter CreateNewParameter(DbCommand dbCommand, string paramName, object paramValue, ParameterDirection paramDirection)
		{
			DbParameter param = dbCommand.CreateParameter();
			param.Direction = paramDirection;
			param.ParameterName = paramName;
			param.Value = paramValue;
			return param;
		}
