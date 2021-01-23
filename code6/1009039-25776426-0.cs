	using System;
	using System.Collections.Generic;
	using System.IdentityModel.Tokens;
	using System.Security.Cryptography;
	using System.ServiceModel;
	using System.ServiceModel.Description;
	using System.ServiceModel.Security;
	using System.ServiceModel.Channels;
	using System.Text;
	using System.Threading.Tasks;
	namespace WSClient
	{
		//Create this custom credentials class to implement UserNameToken autentication
		public class CustomCredentials : ClientCredentials
		{
			public CustomCredentials()
			{ }
			protected CustomCredentials(CustomCredentials cc)
				: base(cc)
			{ }
			public override System.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager()
			{
				return new CustomSecurityTokenManager(this);
			}
			protected override ClientCredentials CloneCore()
			{
				return new CustomCredentials(this);
			}
		}
		public class CustomSecurityTokenManager : ClientCredentialsSecurityTokenManager
		{
			public CustomSecurityTokenManager(CustomCredentials cred)
				: base(cred)
			{ }
			public override System.IdentityModel.Selectors.SecurityTokenSerializer CreateSecurityTokenSerializer(System.IdentityModel.Selectors.SecurityTokenVersion version)
			{
				return new CustomTokenSerializer(System.ServiceModel.Security.SecurityVersion.WSSecurity10);
			}
		}
		public class CustomTokenSerializer : WSSecurityTokenSerializer
		{
			public CustomTokenSerializer(SecurityVersion sv)
				: base(sv)
			{ }
			protected override void WriteTokenCore(System.Xml.XmlWriter writer,
											System.IdentityModel.Tokens.SecurityToken token)
			{
				UserNameSecurityToken userToken = token as UserNameSecurityToken;
				string tokennamespace = "o";
		  
				DateTime created = DateTime.UtcNow;
				string createdStr = created.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"); 
			  
				string phrase = Guid.NewGuid().ToString();
				var nonce = Convert.ToBase64String(Encoding.UTF8.GetBytes(phrase));                                   
				SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
				 //Password_Digest = Base64 ( SHA-1 ( nonce + created + password ) )
				string Password_Digest = Convert.ToBase64String(sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(phrase + createdStr + userToken.Password))); // pxLqPLCXU1EiUS+NnpRuCw==
				var stringToWrite = string.Format(
					"<{0}:UsernameToken u:Id=\"" + token.Id +
					"\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
					"<{0}:Username>" + userToken.UserName + "</{0}:Username>" +
					"<{0}:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest\">" +
					Password_Digest + "</{0}:Password>" +
					"<{0}:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">" +
					nonce + "</{0}:Nonce>" +
					"<u:Created>" + createdStr + "</u:Created></{0}:UsernameToken>", tokennamespace);
				writer.WriteRaw(stringToWrite);
			}
		}
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
				//for invalid ssl server certificate
					System.Net.ServicePointManager.ServerCertificateValidationCallback +=
	(se, cert, chain, sslerror) =>
	{
		return true;
	};
					
					CustomBinding binding = new CustomBinding();
					var security = TransportSecurityBindingElement.CreateUserNameOverTransportBindingElement();
					security.IncludeTimestamp = true;
					security.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256;
					security.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
					security.EnableUnsecuredResponse = true;
					var encoding = new TextMessageEncodingBindingElement();
					encoding.MessageVersion = MessageVersion.Soap11;
					var transport = new HttpsTransportBindingElement();
					transport.MaxReceivedMessageSize = 2000000; 
					binding.Elements.Add(security);
					binding.Elements.Add(encoding);
					binding.Elements.Add(transport);
					WSClient.Proxy.TargetWS client = new Proxy.TargetWS(binding,
						new EndpointAddress(Properties.Settings.Default.Url));
					//change credential for the custom credentials instance
					client.ChannelFactory.Endpoint.Behaviors.Remove<System.ServiceModel.Description.ClientCredentials>();
					client.ChannelFactory.Endpoint.Behaviors.Add(new CustomCredentials());
					client.ClientCredentials.UserName.UserName = Properties.Settings.Default.username;
					client.ClientCredentials.UserName.Password = Properties.Settings.Default.password;
					Proxy.Message message = new WSClient.Proxy.Message();
					message.id = "whatever";
					client.foo(message);
					System.Console.Write("Success");
				}
				catch (Exception ex)
				{
					System.Console.Write(ex.Message);
				}
			}
		}
	}
