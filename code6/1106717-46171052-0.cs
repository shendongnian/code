			...
            // Get an instance of factory.
            factoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
            // Create WMQ Connection Factory.
            cf = factoryFactory.CreateConnectionFactory();
            // Set the properties
            cf.SetStringProperty(XMSC.WMQ_HOST_NAME, CoreMqConfiguration.Hostname);
            cf.SetIntProperty(XMSC.WMQ_PORT, CoreMqConfiguration.Port);
            cf.SetStringProperty(XMSC.WMQ_CHANNEL, CoreMqConfiguration.Channel);
            cf.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT_UNMANAGED);
            cf.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, CoreMqConfiguration.QueueManagerName);
            // for secure communication with SSL            
            cf.SetStringProperty(XMSC.WMQ_SSL_CIPHER_SPEC, CoreMqConfiguration.CipherSpec);
            cf.SetStringProperty(XMSC.WMQ_SSL_KEY_REPOSITORY, "<path\to\ssl>\key");
            // Create connection.
            connectionWMQ = cf.CreateConnection();
			...
