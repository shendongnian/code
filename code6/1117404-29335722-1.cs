        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void HandleMessage(BrokeredMessage message)
        {
            
            var customerMessage = message.GetBody<CustomerMessage>();
            
            switch (customerMessage.EventName)
            {
                case "OnCreated" : 
                    OnCustomerCreated(customerMessage);
                    break;
                case "OnDeleted" : 
                    OnCustomerDeleted(customerMessage as OnDeleted);
                    break;
                case "OnChanged" :
                    OnCustomerChanged(customerMessage as OnChanged);
                    break;
            }
            message.Complete(); //mark the message as completed
        }
