        public class Messanger
    {
        //Singleton
        private Messanger()
        { }
        static Messanger instance;
        public static Messanger Instance
        { 
            get{return instance ?? (instance=new Messanger());}
        }
        static Dictionary<string, Action<Message>> dictionary = new Dictionary<string, Action<Message>>();
        //View Calls this and register the delegate corresponding to the unique token
        public void Register(string token,Action<Message> action)
        {
            if (dictionary.ContainsKey(token))
                throw new Exception("Already registered");
            if (action == null)
                throw new ArgumentNullException("action is null");
            dictionary.Add(token, action);
        }
        public void UnRegister(string token)
        { 
            if(dictionary.ContainsKey(token))
                dictionary.Remove(token);
        }
        //ViewModel Calls this and pass the token and Message.
        //the registered delegate is looked up in dictionary corresponding to that token and
        //Corresponding register delegate fired.
        public void SendMessage(string token,Message message)
        {
            if (dictionary.ContainsKey(token))
                dictionary[token](message);
        }
    }
