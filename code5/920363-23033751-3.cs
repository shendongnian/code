    public void Post(int memberid, dynamic value)
    {
        // Gets the items already in the database
        var x = new cheeAdDCClf3rfFREntities();
        // Create a new message object
        message m = new message();
      
        // Find the highest ID already in the database, then add 1. This is the
        //  ID for our new item
        m.ID = x.messages.Max(record => record.ID) + 1;
   
        // The 'from' property is set to the memberId that the user passed in the POST
        m.from = memberid;
        // The 'message' property is set to whatever dynamic value is passed in the POST
        m.message1 = value.value;
        // Add the message to the database
        x.messages.Add(m);
        x.SaveChanges();
    }
