            internal string ToUri()
            {
                var address = EndPoint.Address.Equals(IPAddress.Any)
                    ? Parent.Parent.Parent.Parent.HostName.ExtractName()
                    : EndPoint.AddressFamily == AddressFamily.InterNetwork
                        ? EndPoint.Address.ToString()
                        : string.Format("[{0}]", EndPoint.Address);
                return IsDefaultPort
                    ? string.Format("{0}://{1}", Protocol, address)
                    : string.Format("{0}://{1}:{2}", Protocol, address, EndPoint.Port);
            }
