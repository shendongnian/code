    private static void Main()
    {
        var queue = new MessageQueue("myQueue");
        queue.PeekCompleted += new PeekCompletedEventHandler(OnPeekCompleted);
         
        // Start listening to queue
        queue.BeginPeek();
    }
    
    private void OnPeekCompleted(object sender, PeekCompletedEventArgs e)
    {
        var cmq = (MessageQueue)sender;
        try
        {
            var msmqMessage = cmq.EndPeek(e.AsyncResult);
            
            msmqMessage.Formatter = new XmlMessageFormatter(typeof(messagetypehere));
            
            var message = msmqMessage.Body;
            
            // Do logic for the message
            {
                // Send mail or what ever
            
            }
            
            cmq.Receive(); // Remove the message from the queue
        }
        catch (Exception ex) 
        {
            // Log or other
        }
        // Refresh queue
        cmq.Refresh();
    
        // Start listening to queue
        cmq.BeginPeek();
    }
