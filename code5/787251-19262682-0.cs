    	private static void CompactAndRepairMDB(string FilePath)
		{
			string FileName		 = Path.GetFileNameWithoutExtension(FilePath);
			string FileName_Temp = Path.GetFileNameWithoutExtension(FilePath) + "_CompactAndRepair";
			string FilePath_Temp = FilePath.Replace(FileName, FileName_Temp);
			JRO.JetEngine oJetEngine = new JRO.JetEngine();
			string SourceConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
						  "Data Source=" + FilePath + ";" + 
						  "Jet OLEDB:Engine Type=5;";
			string DestConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
						"Data Source=" + FilePath_Temp +";" +
						"Jet OLEDB:Engine Type=5;";
			//Compact the database (makes a new copy)
			oJetEngine.CompactDatabase(SourceConn, DestConn);
			//Overrite the old new
			File.Copy(FilePath_Temp, FilePath, true);
			//Delete Temp File
			File.Delete(FilePath_Temp);
		}
		
