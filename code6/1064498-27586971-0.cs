    public class ConversationViewModel 
    {
    	private Func<IMessageViewModel> _messageViewModelFactory;
    	public ConversationViewModel(Func<IMessageViewModel> messageViewModelFactory)
    	{
    		_messageViewModelFactory = messageViewModelFactory;
    	}
    	
    	public void MessageReceived(string data) {
            var messageViewModel = _messageViewModelFactory();
        }
    }
