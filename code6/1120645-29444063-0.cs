        /// <summary>
        /// Moves messages from one queue to another with context
        /// </summary>
        public void moveMessagesWithContext()
        {
            MQQueueManager qmSource = null;
            MQQueueManager qmDestination = null;
            MQQueue qSource = null;
            MQQueue qDestination = null;
            Hashtable htSource = null;
            Hashtable htDestination = null;
            try
            {
                htSource = new Hashtable();
                htDestination = new Hashtable();
                htSource.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                htSource.Add(MQC.HOST_NAME_PROPERTY, "localhost");
                htSource.Add(MQC.PORT_PROPERTY, 2020);
                htSource.Add(MQC.CHANNEL_PROPERTY, "A_QM_SVRCONN");
                qmSource = new MQQueueManager("A_QM", htSource);
                qSource = qmSource.AccessQueue("Q_SOURCE", MQC.MQOO_INPUT_AS_Q_DEF | MQC.MQOO_FAIL_IF_QUIESCING | MQC.MQOO_SAVE_ALL_CONTEXT);
                htDestination.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                htDestination.Add(MQC.HOST_NAME_PROPERTY, "localhost");
                htDestination.Add(MQC.PORT_PROPERTY, 3030);
                htDestination.Add(MQC.CHANNEL_PROPERTY, "B_QM_SVRCONN");
                qmDestination = new MQQueueManager("B_QM", htDestination);
                qDestination = qmDestination.AccessQueue("Q_DESTINATION", MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING | MQC.MQOO_PASS_ALL_CONTEXT);
                MQMessage msgSource = new MQMessage();
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.Options |= MQC.MQGMO_SYNCPOINT;
                qSource.Get(msgSource,gmo);
                if (msgSource != null)
                {
                    MQMessage msgDestination = new MQMessage();
                    MQPutMessageOptions pmo = new MQPutMessageOptions();
                    pmo.ContextReference = qSource;
                    qDestination.Put(msgSource, pmo);
                    qmSource.Commit();
                }
            }
            catch (MQException mqEx)
            {
                qmSource.Backout();
                Console.WriteLine(mqEx);
            }
            catch (Exception otherEx)
            {
                Console.WriteLine(otherEx);
            }
        }
