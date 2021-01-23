    public delegate void CustomEventHandler(object sender, CustomEventArgs e);
    public class CustomEventArgs : EventArgs
    {
        public enum EventTypes
        {
            Success,
            Error
        }
        public CustomEventArgs(string s, EventTypes type)
        {
            msg = s;
            this.type = type;
        }
        private readonly string msg;
        public string Message
        {
            get { return msg; }
        }
        private readonly EventTypes type;
        public EventTypes Type
        {
            get { return type; }
        }
    }
    public class TransactionManager
    {
        public event CustomEventHandler CustomEvent;
        public void PerformTransaction()
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    //Perform your workload
                    scope.Complete();
                }
                if (CustomEvent != null)
                    CustomEvent(this,
                        new CustomEventArgs("Transaction performed successfully message",
                            CustomEventArgs.EventTypes.Success));
            }
            catch (Exception exception)
            {
                if (CustomEvent != null)
                    CustomEvent(this,
                        new CustomEventArgs(exception.Message, CustomEventArgs.EventTypes.Error));                
            }
        }
        
    }
    public class Engine
    {
        public void PerformWorkload()
        {
            var tm = new TransactionManager();
            tm.CustomEvent += transaction_CustomEvent;
            tm.PerformTransaction();
        }
        private void transaction_CustomEvent(object sender, CustomEventArgs e)
        {
            //Simulate send operation successful mail
            switch (e.Type)
            {
                case CustomEventArgs.EventTypes.Error:
                    //Send error mail
                    break;
                case CustomEventArgs.EventTypes.Success:
                    //Send success email
                    break;
            }
        }
    }
