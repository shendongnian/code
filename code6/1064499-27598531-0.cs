    public class ViewModelLocator
    {
        public class ViewModelLocator()
        {
           //creates instance immediately
           SimpleIoc.Default.Register<MessageViewModel>(true);
        }
    }
    public class MessageViewModel:ViewModelBase
    {
         public MessageViewModel()
         {
            MessengerInstance.Register<string>(this,DoSomething);
         }
         public void DoSomething(string data)
         {
                 //do stuff
         }
    }
    public class ConversationViewModel:ViewModelBase
    {
         public void MessageReceived(string data)
         {
           MessengerInstance.Send<string>(data);//this will trigger DoSomething in MessageViewModel
         }
    }
