    public class ConnectionInfo
    {
       public string T;
       public string Code;
       public string Message;
    }
    public ConnectionInfo CreateTransaction()
    {
         var tCompResp = new ConnectionInfo{T=T, Code=TCode, Message=Message};
         return tCompResp;
    }
    
