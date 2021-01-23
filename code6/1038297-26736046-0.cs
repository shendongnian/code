                MQMessage msg = new MQMessage();
                queue.Get(msg, mqGetMsgOpts);
                MQGetMessageOptions mqGetNextMsgOpts = new MQGetMessageOptions();
                mqGetNextMsgOpts.Options = MQC.MQGMO_BROWSE_NEXT;
                try
                {
                    while (true)
                    {
                        string messageText = msg.ReadString(msg.MessageLength);
                        //Write to File
                        byte[] byteConent = new byte[msg.MessageLength];
                        msg.ReadFully(ref byteConent, 0, msg.MessageLength);
                        File.WriteAllBytes("sample.eff", byteConent);
                        //
                        msg = new MQMessage();
                        queue.Get(msg, mqGetNextMsgOpts);
                    }
                }
                catch (MQException ex)
                {
                    // Handle it
                }
