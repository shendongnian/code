    public List<MessageToShow> Get()
    {   
         // Looks like EntityFramework? Represents the items already in database
         var x = new cheeAdDCClf3rfFREntities();
         // Take to top 100 item already in the database
         var  y=x.messages.Take(100);
         // Create a new list to hold the messages we will return
         List<MessageToShow> messageToShow = new List<MessageToShow>();
         // For each message in the 100 we just took
         foreach (var xx in y)
         {
             MessageToShow m = new MessageToShow();
             // Get the details of the member that send this message
             member me = x.members.FirstOrDefault(j => j.ID == xx.from);
             // If we found the member, create a message to show
             //  (populating the message and the username of the member
             //  who sent it)
             if (me != null)
             {
                 m.from = me.username;
                 m.message = xx.message1;
                 messageToShow.Add(m);
             }
         }
         // Return the list of messages we just created to the caller of the API
         return messageToShow;
    }
