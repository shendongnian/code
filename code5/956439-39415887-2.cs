        private static void SetCertificateValidator()
        {
            var retriableCertificateValidatorType = Type.GetType("Microsoft.ServiceBus.Channels.Security.RetriableCertificateValidator, Microsoft.ServiceBus", true, false);
            var instanceProperty = retriableCertificateValidatorType.GetProperty("Instance", BindingFlags.Static | BindingFlags.NonPublic);
            var instance = instanceProperty.GetValue(null);
            var peerOrChainTrustNoCheck = retriableCertificateValidatorType.GetField("peerOrChainTrustNoCheck", BindingFlags.Instance | BindingFlags.NonPublic);
            peerOrChainTrustNoCheck?.SetValue(instance, new EmptyOpX509CertificateValidator());
        }
        private sealed class EmptyOpX509CertificateValidator : X509CertificateValidator
        {
            public override void Validate(X509Certificate2 certificate)
            {
            }
        }
