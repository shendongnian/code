    using Lextm.SharpSnmpLib;
    using Lextm.SharpSnmpLib.Messaging;
     var result = Messenger.Get(
         				VersionCode.V1,
          				new IPEndPoint(IPAddress.Parse("172.10.206.108"), 161),
           				new OctetString("public"),
           				new List<Variable> { new Variable(new ObjectIdentifier("1.3.6.1.4.1.2021.4.6.0")) },
           				60000);
