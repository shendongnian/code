     using (
       var client = new NamedPipeClientStream(".", "PipesEnroll", PipeDirection.InOut,
                    PipeOptions.None, TokenImpersonationLevel.Impersonation))
                    {
                     client.Connect();
                     var ss = new StreamString(client);
                     string xmlReceive = ss.ReadString();
                     var dtoReceived = ServerData.Deserialize(xmlReceive);
                     bool isOK = dtoReceived.Result;
                    string terminalTemplate = dtoReceived.Str1;
                     string matcherTemplate = dtoReceived.Str2;
                     int numberFingers = dtoReceived.Int1;
        }
    }
