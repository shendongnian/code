			DbSyncTableDescription CountriesTableDescription;
			if (provider.Connection.Database.ToLower() == "peer1")
				CountriesTableDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable( "Countries_Version", (System.Data.SqlClient.SqlConnection)provider.Connection );
			else
				CountriesTableDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable( "Countries", (System.Data.SqlClient.SqlConnection)provider.Connection );
			 
			// map to the Countries_Version table on peer2
			CountriesTableDescription.GlobalName = "Countries";
