        public class MySecurityHeader : AddressHeader
        {
            public override string Name
            {
                get { return "Security"; }
            }
            public override string Namespace
            {
                get { return "<provide the appropiate namespace>"; }
            }
            protected override void OnWriteAddressHeaderContents(System.Xml.XmlDictionaryWriter writer)
            {
                // here you do what you want
                writer.WriteRaw(String.Format(@"
                 <UsernameToken xmlns=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                 <Username>user</Username>
                 <Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">pass</Password>
                 </UsernameToken>").Trim());
            }
        }
