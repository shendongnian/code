    Guid pipeGuid;
    if (PipeName.Equals("*", StringComparison.InvariantCultureIgnoreCase) || PipeName.Equals("localhost", StringComparison.InvariantCultureIgnoreCase))
         PipeName = "*";
                
    string s = string.Format(@"net.pipe://{0}/", PipeName.ToUpper());
    if(!string.IsNullOrWhiteSpace(ServiceName))
         s = string.Format(@"net.pipe://*/{0}/", ServiceName.ToUpper());
    var bytes = Encoding.UTF8.GetBytes(s);
    var base64 = Convert.ToBase64String(bytes);
    string namedPipeMMFName = string.Format(@"Global\net.pipe:E{0}", base64);
    MemoryMappedFileSecurity mSec = new MemoryMappedFileSecurity();
    mSec.AddAccessRule(new AccessRule<MemoryMappedFileRights>(new     SecurityIdentifier(WellKnownSidType.WorldSid, null),  MemoryMappedFileRights.FullControl, AccessControlType.Allow));
    using (var mmf = MemoryMappedFile.OpenExisting(namedPipeMMFName, MemoryMappedFileRights.Read))
    {
        using (var accessor = mmf.CreateViewAccessor(4, 45, MemoryMappedFileAccess.Read))
        {
            accessor.Read<Guid>(0, out pipeGuid);
        }
    }
    using (NamedPipeClientStream client = new NamedPipeClientStream(GetResolvedText(ServerName), pipeGuid, PipeDirection.InOut,
                            PipeOptions.None, TokenImpersonationLevel.Impersonation))
    {
        client.Connect(10000);
    }
