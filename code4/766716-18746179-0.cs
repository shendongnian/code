    using Newtonsoft.Json;
    using System;
    using System.IdentityModel.Protocols.WSTrust;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Security;
    using System.Text;
    using System.Xml;
    using Thinktecture.IdentityModel.Extensions;
    using Thinktecture.IdentityModel.WSTrust;
    namespace SimpleWebConsole
    {
    internal class ADFS
    {
        public static void tokenTest()
        {
            string relyingPartyId = "https://party.mycomp.com";
            WSTrustChannelFactory factory = null;
            try
            {
                // use a UserName Trust Binding for username authentication
                factory = new WSTrustChannelFactory(
                    new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                     new EndpointAddress("https://adfs.mycomp.com/adfs/services/trust/13/usernamemixed"));
                factory.TrustVersion = TrustVersion.WSTrust13;
                factory.Credentials.UserName.UserName = "test";
                factory.Credentials.UserName.Password = "test";
                var rst = new RequestSecurityToken
                {
                    RequestType = RequestTypes.Issue,
                    AppliesTo = new EndpointReference(relyingPartyId),
                    KeyType = KeyTypes.Bearer
                };
                IWSTrustChannelContract channel = factory.CreateChannel();
                GenericXmlSecurityToken genericToken = channel.Issue(rst) as GenericXmlSecurityToken; //MessageSecurityException -> PW falsch
                var _handler = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();
                var tokenString = genericToken.ToTokenXmlString();
                var samlToken2 = _handler.ReadToken(new XmlTextReader(new StringReader(tokenString)));
                ValidateSamlToken(samlToken2);
                X509Certificate2 certificate = null;
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                certificate = store.Certificates.Find(X509FindType.FindByThumbprint, "thumb", false)[0];
                var jwt=ConvertSamlToJwt(samlToken2, "https://party.mycomp.com", certificate);
            }
            finally
            {
                if (factory != null)
                {
                    try
                    {
                        factory.Close();
                    }
                    catch (CommunicationObjectFaultedException)
                    {
                        factory.Abort();
                    }
                }
            }
        }
        public static TokenResponse ConvertSamlToJwt(SecurityToken securityToken, string scope, X509Certificate2 SigningCertificate)
        {
            var subject = ValidateSamlToken(securityToken);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                AppliesToAddress = scope,
                SigningCredentials = new X509SigningCredentials(SigningCertificate),
                TokenIssuerName = "https://panav.mycomp.com",
                Lifetime = new Lifetime(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10080))
            };
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwt = jwtHandler.CreateToken(descriptor);
            return new TokenResponse
            {
                AccessToken = jwtHandler.WriteToken(jwt),
                ExpiresIn = 10080
            };
        }
        public static ClaimsIdentity ValidateSamlToken(SecurityToken securityToken)
        {
            var configuration = new SecurityTokenHandlerConfiguration();
            configuration.AudienceRestriction.AudienceMode = AudienceUriMode.Never;
            configuration.CertificateValidationMode = X509CertificateValidationMode.None;
            configuration.RevocationMode = X509RevocationMode.NoCheck;
            configuration.CertificateValidator = X509CertificateValidator.None;
            var registry = new ConfigurationBasedIssuerNameRegistry();
            registry.AddTrustedIssuer("thumb", "ADFS Signing - mycomp.com");
            configuration.IssuerNameRegistry = registry;
            var handler = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection(configuration);
            var identity = handler.ValidateToken(securityToken).First();
            return identity;
        }
        public class TokenResponse
        {
            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }
            [JsonProperty(PropertyName = "token_type")]
            public string TokenType { get; set; }
            [JsonProperty(PropertyName = "expires_in")]
            public int ExpiresIn { get; set; }
            [JsonProperty(PropertyName = "refresh_token")]
            public string RefreshToken { get; set; }
        }
    }
    }
