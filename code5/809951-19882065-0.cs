    public int ServerState
        {
            get
            {
                return serverState;
            }
            set
            {
                if (InvalidState(Value))
                {
                    var to = OperationContext.Current.GetCallbackChannel<ISAPUploadServiceReply>();
                    Task.Factory.StartNew(() =>
                        {
                            to.Reply(eInvalidState);
                        });
                    
                }
                else
                    serverState = value;
            }
        }
