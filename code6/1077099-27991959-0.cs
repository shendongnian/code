	private void IPlatypusDBUtils.SaveSiteMappingData(IEnumerable<SiteMapping> siteMappings) {
		ExceptionLoggingService.Instance.WriteLog("Reached TestPlatypusDBUtils.SaveSiteMappingData");
		string sqlCmd =
			@"INSERT INTO SiteMapping " +
			"(Id, SiteNumber, LocationNumber, SiteName) " +
			"VALUES " +
			"(@Id, @SiteNumber, @LocationNumber, @SiteName)";
		using (var cmd = new SQLiteCommand(sqlCmd, new SQLiteConnection(PlatypusUtils.GetDBConnection()))) {
            // Setup your parameters here,
            // using the data types found in your database,
            // before ever opening the database connection.
			cmd.Parameters.Add("@Id", DbType.Int);
			cmd.Parameters.Add("@SiteNumber", DbType.VarChar, 50); // or Platypusconsts.currentsitenum ?
			cmd.Parameters.Add("@LocationNumber", DbType.Int);
			cmd.Parameters.Add("@SiteName", DbType.VarChar, 50);
			try { // now open your connection
				cmd.Connection.Open();
				foreach (var sm in siteMappings) {
					cmd.Parameters["@Id"].Value = sm.Id;
					cmd.Parameters["@SiteNumber"].Value = sm.SiteNumber.ToString();
					cmd.Parameters["@LocationNumber"].Value = sm.LocationNumber;
					cmd.Parameters["@SiteName"].Value = sm.SiteName;
					cmd.ExecuteNonQuery();
				}
			} catch (SQLiteException ex) {
                // Focus your Exception on the SQLiteException
				String msgInnerExAndStackTrace = String.Format(
						"{0}; Inner Ex: {1}; Stack Trace: {2}", ex.Message, ex.InnerException, ex.StackTrace);
				ExceptionLoggingService.Instance.WriteLog(String.Format("Exception in TestPlatypusDBUtils.SaveSiteMappingData: {0}", msgInnerExAndStackTrace));
			} finally {
                // Placing your Close command here will work even if
                // the code throws an exception.
				cmd.Connection.Close();
			}
		}
	}
