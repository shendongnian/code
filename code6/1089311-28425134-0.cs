    try {
       var message = await GetMessagesAsync();
    }
    catch (Exception ex) {
      LogException(ex); 
    }
    async Task<IEnumerable<Message>> GetMessagesAsync() {....}
   
