                MyPrintWebServiceSoapClient ws = new MyPrintWebServiceSoapClient();
                ws.ChannelFactory.Endpoint.Address = new EndpointAddress(new Uri(xxx.asmx"));
                ws.InnerChannel.OperationTimeout = TimeSpan.FromMilliseconds(6000);
                using (OperationContextScope scope = new OperationContextScope(ws.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageHeaders.Add(authSoapdHd);
                    ws.LogInCompleted += ws_LogInCompleted;
                    LogInRequest request = new LogInRequest(xxx, yyy);
                    ws.LogInAsync(request);
                }
