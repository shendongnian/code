    public class CertificateWebClient : WebClient
    {
        private readonly string _certificateUri;
        public CertificateWebClient(string certificateUri)
        {
            _certificateUri = certificateUri;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var clientCertificate = new X509Certificate2(HostingEnvironment.MapPath(_certificateUri), "", X509KeyStorageFlags.MachineKeySet);
            request.ClientCertificates.Add(clientCertificate);
            return request;
        }
    }
