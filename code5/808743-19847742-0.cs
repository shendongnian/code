      public static bool ValidateCertificate(
       object sender,
       X509Certificate certificate,
       X509Chain chain,
       SslPolicyErrors errors)
       {
            if (errors == SslPolicyErrors.None)
                return true;
            if (certificate != null)
            {
                string SendingCertificateName = "";
                //List<string> Subject = CommaText(certificate.Subject); // decode commalist
                // SendingCertificateName = ExtractNameValue(Subject, "CN"); // get the CN= value
                report = string.Format(CultureInfo.InvariantCulture, "certificatename : {0}, SerialNumber: {1}, {2}, {3}", certificate.Subject, certificate.GetSerialNumberString(), SendingCertificateName, ServerName);
                Console.WriteLine(report);
             }
        
             Console.WriteLine("Certificate error: {0}", errors);
             int allow = AllowPolicyErrors << 1;  // AllowPolicyErrors property allowing you to pass certain errors
             return (allow & (int)sslPolicyErrors) == (int)sslPolicyErrors;  // or just True if you dont't mind.
        }
