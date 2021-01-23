        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
        {
            if (errors == SslPolicyErrors.None)
            {
                return true;
            }
            var hashString = certificate.GetCertHashString();
            var isTrusted = trustedCertificates.Contains(hashString);
            if (!isTrusted)
            {
                telemetryClient.TrackTrace($"Untrusted: {hashString} Errors: {errors} Cert: {certificate.ToString()}", SeverityLevel.Warning);
            }
            return isTrusted;
        };
