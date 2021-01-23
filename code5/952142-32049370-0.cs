    DecodedShortMessage[] messages = comm.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Sim);
        
       foreach (DecodedShortMessage message in messages)
           {
                              
               SmsPdu rawmsg = message.Data;
               SmsDeliverPdu msg = (SmsDeliverPdu)rawmsg;
               string message = msg.UserDataText;
               string sender =  msg.OriginatingAddress;
        
            }
