    public bool CreateSubTopic(string subtopic, DateTime enddate, int maxParts, int BitKeepEntries)
    {
       Connected = true;
       var myDict = GetSubtopics(HelpClass.TopicId);
       if (myDict.ContainsKey(subtopic))
       {
        return false;
       }
        myCommand = null;
        myCommand = new SqlCommand("insert into SubtopicsParameters(FK_Topic, Subtopic, StartDate, Enddate, MaxParticipants, KeepsEntries) values(@topic,@stopic,@sd,@ed,@partici,@KEntries);
		if(HelpClass.TopicId=="")
			myCommand.Parameters.AddWithValue("@topic",System.DBNull.Value);
		else 
			myCommand.Parameters.AddWithValue("@topic",HelpClass.TopicId);
		
		if(subtopic=="")
			myCommand.Parameters.AddWithValue("@stopic",System.DBNull.Value);
		else 
			myCommand.Parameters.AddWithValue("@stopic",subtopic);
		
		myCommand.Parameters.AddWithValue("@sd",DateTime.Today);
			
		if(enddate=="")
			myCommand.Parameters.AddWithValue("@ed",System.DBNull.Value);
		else 
			myCommand.Parameters.AddWithValue("@ed",enddate);
			
		if(maxParts=="")
			myCommand.Parameters.AddWithValue("@partici",System.DBNull.Value);
		else 
			myCommand.Parameters.AddWithValue("@partici",maxParts);	
			
		if(BitKeepEntries=="")
			myCommand.Parameters.AddWithValue("@KEntries",System.DBNull.Value);
		else 
			myCommand.Parameters.AddWithValue("@KEntries",BitKeepEntries);		
			
		myCommand.ExecuteNonQuery();
		Connected = false;
		return true;
	}
