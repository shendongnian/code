    var emailList = new List<String>();
    while (reader.Peek() >= 0)
    {
    	emailList.Add(reader.ReadLine());
    	if(emailList.Count == 1000)
    	{
    		SendEmails(emailList);
    		emailList = new List<String>();
    	}
    }
    //send the rest, if any
    if(emailList.Any()) SendEmails(emailList);
