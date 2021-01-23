     public RpcResponseResult GetActualResponseType()
     {
         if(HostPort != -1 && !string.IsNullOrEmtpy(HostName))
         {
             return new RpcExtendedResponseResult() { Code = this.Code, HostName = this.HostName, HostPort = this.HostPort};
         }
         return new RpcResponseResult() { Code = this.Code };
     }
