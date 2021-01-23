    public class MessageManager{
        
        private Dictionary<string,List<MessageListener>> listeners;
        
        public void sendMessage(Message m){
            //loop over listeners of m
        }
        public void addMessageListener(MessageListener ml){
             //add a listener
        }
        
        public void removeMessageListener(MessageListener ml){
             //remove a listener
        }
    }
