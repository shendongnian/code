	using (SqlConnection conn = new SqlConnection(...)){
		conn.Open();
		
		using (SqlCommand selectPriser = new SqlCommand("SELECT priser FROM Priser WHERE Id = @ppId;", conn))
		{
			selectPriser.Parameters.AddWithValue("@ppId", prisId);
			
			using (SqlDataReader readerPriser = selectPriser.ExecuteReader())
			{
				if (readerPriser.Read())
				{
					// ...
					using (SqlCommand selectBrugere = new SqlCommand("SELECT id, brugernavn, fornavn, efternavn FROM brugere WHERE Id = @brugerid;"){
						string Brugerid = Session["id"].ToString();
						selectBrugere.Parameters.AddWithValue("@brugerid", Brugerid);
						using (SqlDataReader readerBrugerid = selectBrugere.ExecuteReader()){
							if (readerBrugerid.Read()){
								// ...
							}
						}
					}
				}
			}
		}
	}
	
