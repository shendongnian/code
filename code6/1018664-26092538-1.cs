            MQQueueManager qm = null;
            System.Environment.SetEnvironmentVariable("MQCHLLIB", "C:\\ProgramData\\IBM\\MQ\\qmgrs\\QM1\\@ipcc");
            System.Environment.SetEnvironmentVariable("MQCHLTAB", "AMQCLCHL.TAB");
            try
            {
                **Hashtable props = new Hashtable();
                props.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_CLIENT);
                qm = new MQQueueManager("QM1",props);**
                MQQueue queue1 = qm.AccessQueue("SYSTEM.DEFAULT.LOCAL.QUEUE", MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING);
                MQMessage msg = new MQMessage();
                msg.WriteUTF("Hello this message is from .net client");
                queue1.Put(msg);
                queue1.Close();
                qm.Disconnect();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
