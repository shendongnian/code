     public class ViewBase:Window
    {
        protected  string Token { get; private set; }
        public ViewBase()
        {
            Token = Guid.NewGuid().ToString();
            
            //Register to Messanger
            Messanger.Instance.Register(Token, HandleMessages);
            //UnRegister On Closing or Closed
            this.Closing +=(s,e)=> Messanger.Instance.UnRegister(Token);
        }
        //Handle Common Messages to all Windows Here
        void HandleMessages(Message message)
        {
            switch (message.MessageType)
            { 
                case MessageType.OpenExceptionWindow:
                    Exception ex = message.MessageObject as Exception;
                    ExceptionWindow window = new ExceptionWindow();
                    window.Exception = ex;
                    window.ShowDialog();
                    break;
                    //other common cases should be handled here
                default : HandleWindowLevelMessage(message);
                    break;
            }
            
        }
        protected virtual void HandleWindowLevelMessage(Message message)
        { 
        
        }
    }
