        private struct SoapFault {
            public string Subcode;
            public string Reason;
            public string Detail;
        }
        private static string GetTextChild(XmlReader xmr, string childName) {
          return xmr.ReadToDescendant(childName) ? 
              xmr.ReadString() : System.String.Empty;
        }
        private static SoapFault GetSoapFault(System.IO.Stream s) {
            var xr = XmlReader.Create(s);
            var fault = new SoapFault();
            if (xr.ReadToFollowing("SOAP-ENV:Subcode")) {
                fault.Subcode = GetTextChild(xr, "SOAP-ENV:Value");
                if (xr.ReadToFollowing("SOAP-ENV:Reason")) {
                    fault.Reason = GetTextChild(xr, "SOAP-ENV:Text");
                    if (xr.ReadToFollowing("SOAP-ENV:Detail"))
                        fault.Detail = GetTextChild(xr, "SOAP-ENV:Text");
                }
            }
            return fault;
        }
