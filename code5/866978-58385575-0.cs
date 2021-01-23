    // private fields
    private static readonly string _apnsHostName = ConfigurationManager.AppSettings["APNS:HostName"];
    private static readonly int _apnsPort = int.Parse(ConfigurationManager.AppSettings["APNS:Port"]);
    private static readonly string _apnsCertPassword = ConfigurationManager.AppSettings["APNS:CertPassword"];
    private static readonly string _apnsCertSubject = ConfigurationManager.AppSettings["APNS:CertSubject"];
    private static readonly string _apnsCertPath = ConfigurationManager.AppSettings["APNS:CertPath"];
    private readonly ILogger _log;
    private X509Certificate2Collection _certificatesCollection;
    ctor <TAB key>(ILogger log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
        // load .p12 certificate in the collection
        var cert = new X509Certificate2(_apnsCertPath, _apnsCertPassword);
        _certificatesCollection = new X509Certificate2Collection(cert);
    }
    
    public async Task SendAppleNativeNotificationAsync(string payload, Registration registration)
    {
        try
        {
            // handle is the iOS device Token
            var handle = registration.Handle;
            
            // instantiate new TcpClient with ApnsHostName and Port
            var client = new TcpClient(_apnsHostName, _apnsPort);
            // add fake validation
            var sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
            try
            {
                // authenticate ssl stream on ApnsHostName with your .p12 certificate
                sslStream.AuthenticateAsClient(_apnsHostName, _certificatesCollection, SslProtocols.Tls, false);
                var memoryStream = new MemoryStream();
                var writer = new BinaryWriter(memoryStream);
                writer.Write((byte)0);
                writer.Write((byte)0);
                writer.Write((byte)32);
                writer.Write(HexStringToByteArray(handle.ToUpper()));
                writer.Write((byte)0);
                writer.Write((byte)Encoding.UTF8.GetByteCount(payload));
                byte[] b1 = Encoding.UTF8.GetBytes(payload);
                writer.Write(b1);
                writer.Flush();
                byte[] array = memoryStream.ToArray();
                await sslStream.WriteAsync(array, 0, array.Length);
                // TIP: do not wait a response from APNS because APNS return a response only when an error occurs; 
                // so if you wait the response your code will remain stuck here.
                // await ReadTcpResponse();
                sslStream.Flush();
                
                // close client
                client.Close();
            }
            catch (AuthenticationException ex)
            {
                _log.Error($"Error sending APNS notification. Exception: {ex}");
                client.Close();
            }
            catch (Exception ex)
            {
                _log.Error($"Error sending APNS notification. Exception: {ex}");
                client.Close();
            }
        }
        catch (Exception ex)
        {
            _log.Error($"Error sending APNS notification. Exception: {ex}");
        }
    }
    private static byte[] HexStringToByteArray(string hex)
    {
    	if (hex == null)
        {
        	return null;
        }
        // added for newest devices (>= iPhone 8)
        if (hex.Length % 2 == 1)
        {
        	hex = '0' + hex;
        }
        return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
    }
    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
        //if (sslPolicyErrors == SslPolicyErrors.None)
        //    return true;
        //// do not allow this client to communicate with unauthenticated servers.
        //return false;
    }
    private async Task<byte[]> ReadTcpResponse(SslStream sslStream)
    {
        MemoryStream ms = new MemoryStream();
        byte[] buffer = new byte[2048];
        int bytes = -1;
        do
        {
            bytes = await sslStream.ReadAsync(buffer, 0, buffer.Length);
            await ms.WriteAsync(buffer, 0, bytes);
        } while (bytes != 0);
        return ms.ToArray();
    }
