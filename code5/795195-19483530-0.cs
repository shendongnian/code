    class Message
    {
    	public readonly String Author;
    	public readonly String Content;
    	public readonly DateTimeOffset Time = DateTimeOffset.UtcNow;
    	public Message(String author, String content)
    	{
    		Author = author;
    		Content = content;
    	}
    }
    
    class Chat
    {
    	// collection of recent messages
    	private IList<Message> _recentMessages = new List<Message>();
    
    	public void ChatMessageReceived(String author, String content)
    	{
    		// prune the recentMessages down to only messages in the last minute
    		var oneMinuteAgo = DateTimeOffset.UtcNow - TimeSpan.FromMinutes(1);
    		_recentMessages = (from message in _recentMessages where message.Time > oneMinuteAgo select message).ToList();
    
    		// get the number of recent messages sent by this author
    		var countOfRecentMessagesFromAuthor = _recentMessages.Count(message => message.Author == author);
    		if (countOfRecentMessagesFromAuthor > 10)
    			return;
    
    		// add the new message to the collection of recent messages.
    		_recentMessages.Add(new Message(author, content));
    
    		// Record the chat message and display it or send it to connected clients.
    	}
    }
