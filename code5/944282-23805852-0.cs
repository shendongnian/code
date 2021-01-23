    public delegate void DelegateMessageQueueTableUpdate();
    public event DelegateMessageQueueTableUpdate MessageQueueTableUpdate;
    
    private void FirebirdRemoteEventOnRemoteEventCounts(object sender, FbRemoteEventEventArgs fbRemoteEventEventArgs)
            {
                switch (fbRemoteEventEventArgs.Name.Trim().ToUpper())
                {
                    case "QUEUE_NEW_MESSAGE":
                        if (fbRemoteEventEventArgs.Counts > 0)
                        {
                            if (MessageQueueTableUpdate != null)
                            {
                                MessageQueueTableUpdate();
                            }
                        }
                        break;
                }
            }
