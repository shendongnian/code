    while(true){
     DecodedShortMessage[] messages =
         gsmCommMain.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Sim);
        foreach (var decodedShortMessage in messages)
        {
               var msgData = decodedShortMessage.Data.UserDataText;
              int indexP = decodedShortMessage.Index;
              gsmCommMain.DeleteMessage(indexP, PhoneStorageType.Sim);
              //  gsmCommMain.DeleteMessages(DeleteScope.Read, PhoneStorageType.Sim); delete all msg
        
        
           } 
    }
