    [ServiceContract]
    public interface IMessage
    {
        [OperationContract]
        Task<string> GetMessages(string msg);
    }
    public class MessageService : IMessage
    {
       async Task<string> IMessage.GetMessages(string msg)
       {
          var task = Task.Factory.StartNew(() =>
                                         {
                                             Thread.Sleep(10000);
                                             return "Return from Server : " + msg;
                                         });
         return await task.ConfigureAwait(false);
       }
    }
