    string queueManagerName = "QM_LOCAL";
    string queueName = "DeleteMeQueue";
    
    Hashtable options = new Hashtable();
    
    // This is a connection to a local server. For a remote server use 'TRANSPORT_MQSERIES_CLIENT', 'TRANSPORT_MQSERIES_XACLIENT' or 'TRANSPORT_MQSERIES_MANAGED'
    options.Add(IBM.WMQ.MQC.TRANSPORT_PROPERTY, "TRANSPORT_MQSERIES_BINDINGS");
    
    // For 'TRANSPORT_MQSERIES_CLIENT', 'TRANSPORT_MQSERIES_XACLIENT' or 'TRANSPORT_MQSERIES_MANAGED' uncomment the below
    // string hostName = "RemoteServerName";
    // string channelName = "SYSTEM.ADMIN.SVRCONN";
    // int portNumber = 1414;
    // options.Add(IBM.WMQ.MQC.HOST_NAME_PROPERTY, hostName);
    // options.Add(IBM.WMQ.MQC.CHANNEL_PROPERTY, channelName);
    // options.Add(IBM.WMQ.MQC.PORT_PROPERTY, portNumber);
    // options.Add(IBM.WMQ.MQC.CONNECT_OPTIONS_PROPERTY, IBM.WMQ.MQC.MQC.MQCNO_STANDARD_BINDING);
    IBM.WMQ.MQQueueManager queueManager = null;
    IBM.WMQ.PCF.PCFMessageAgent agent = null;
    try
    {
        // Initialize a connection to the (remote) queuemanager and a PCF message agent.
        queueManager = new IBM.WMQ.MQQueueManager(queueManagerName, options);
        agent = new IBM.WMQ.PCF.PCFMessageAgent(queueManager);
    
        // Create queue
        IBM.WMQ.PCF.PCFMessage createRequest = new IBM.WMQ.PCF.PCFMessage(IBM.WMQ.PCF.CMQCFC.MQCMD_CREATE_Q);
        createRequest.AddParameter(IBM.WMQ.MQC.MQCA_Q_NAME, queueName);
        createRequest.AddParameter(IBM.WMQ.MQC.MQIA_Q_TYPE, IBM.WMQ.MQC.MQQT_LOCAL);
        createRequest.AddParameter(IBM.WMQ.MQC.MQIA_DEF_PERSISTENCE, IBM.WMQ.MQC.MQPER_PERSISTENT);
        createRequest.AddParameter(IBM.WMQ.MQC.MQCA_Q_DESC, "Created by " + Environment.UserName + " on " + DateTime.UtcNow.ToString("o"));
        IBM.WMQ.PCF.PCFMessage[] createResponses = agent.Send(createRequest);
    
        // Delete queue
        IBM.WMQ.PCF.PCFMessage deleteRequest = new IBM.WMQ.PCF.PCFMessage(IBM.WMQ.PCF.CMQCFC.MQCMD_DELETE_Q);
        deleteRequest.AddParameter(IBM.WMQ.MQC.MQCA_Q_NAME, queueName);
        IBM.WMQ.PCF.PCFMessage[] deleteResponses = agent.Send(deleteRequest);
    }
    finally
    {
        // Disconnect the agent and queuemanager.
        if (agent != null) agent.Disconnect();
        if (queueManager != null && queueManager.IsConnected) queueManager.Disconnect();
    }
