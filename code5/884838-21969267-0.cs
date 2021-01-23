    private void InsertData()
    {
    	using (var Connection = new SqlConnection(connectionString))
    	{
    		string NewCode = GenerateCode();
    		string NewSentence = txtSentence.Text;
    		string NewRow = NewRowNum();
    		try
    		{
    			Connection.Open();
    			string AddData = "INSERT INTO ShopSentences (BinaryStrings,Sentence,RowNumber) VALUES (@NewBinaryString,@NewSentence,@NewRowNumber)";
    			SqlCommand DataAdd = new SqlCommand(AddData, Connection);
    			DataAdd.Parameters.AddWithValue("@NewBinaryString", NewCode);
    			DataAdd.Parameters.AddWithValue("@NewNewSentence", NewSentence);
    			DataAdd.Parameters.AddWithValue("@NewRowNumber", NewRow);
    			DataAdd.ExecuteNonQuery();
    			//Connection.Close(); no need to close
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine(e.ToString());
    		}
    	}
    }
