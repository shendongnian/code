    GeneralServicesClient Ret = new GeneralServicesClient(Consts.WcfGeneralChannels.TcpIp);
    using (OperationContextScope scope = new OperationContextScope(Ret.InnerChannel))
         {
             OperationContext.Current.OutgoingMessageProperties.Add("Token", Guid.NewGuid());
             Ret.Do();
         }
