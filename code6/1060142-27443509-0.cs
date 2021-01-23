	public class mySAMLClient : IAuthenticationClient
	{
		// I store the IDP certificate in App_Data
		// This can by actually skipped. See VerifyAuthentication for more details
		private static X509Certificate2 certificate = null;
		private X509Certificate2 Certificate
		{
			get
			{
				if (certificate == null)
				{
					certificate = new X509Certificate2(Path.Combine(HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data"), "idp.cer"));
				}
				return certificate;
			}
		}
		private string providerName;
		public string ProviderName
		{
			get
			{
				return providerName;
			}
		}
		public mySAMLClient()
		{
			// This probably should be provided as a parameter for the constructor, but in my case this is enough
			providerName = "mySAML";
		}
		public void RequestAuthentication(HttpContextBase context, Uri returnUrl)
		{
			// Normally you would need to request assertion here, but in my case redirecting to certain address was enough
			context.Response.Redirect("IDP login address");
		}
		public AuthenticationResult VerifyAuthentication(HttpContextBase context)
		{
			// For one reason or another I had to redirect my SAML callback (POST) to my OAUTH callback (GET)
			// Since I needed to retain the POST data, I temporarily copied it to session
			var response = context.Session["SAMLResponse"].ToString();
			context.Session.Remove("SAMLResponse");
			if (response == null)
			{
				throw new Exception("Missing SAML response!");
			}
			// Decode the response
			response = Encoding.UTF8.GetString(Convert.FromBase64String(response));
			
			// Parse the response
			var assertion = new XmlDocument { PreserveWhitespace = true };
			assertion.LoadXml(response);
			//Validating signature based on: http://stackoverflow.com/a/6139044
			// adding namespaces
			var ns = new XmlNamespaceManager(assertion.NameTable);
			ns.AddNamespace("samlp", @"urn:oasis:names:tc:SAML:2.0:protocol");
			ns.AddNamespace("saml", @"urn:oasis:names:tc:SAML:2.0:assertion");
			ns.AddNamespace("ds", @"http://www.w3.org/2000/09/xmldsig#");
			// extracting necessary nodes
			var responseNode = assertion.SelectSingleNode("/samlp:Response", ns);
			var assertionNode = responseNode.SelectSingleNode("saml:Assertion", ns);
			var signNode = responseNode.SelectSingleNode("ds:Signature", ns);
			// loading the signature node
			var signedXml = new SignedXml(assertion.DocumentElement);
			signedXml.LoadXml(signNode as XmlElement);
			
			// You can extract the certificate from the response, but then you would have to check if the issuer is correct
			// Here we only check if the signature is valid. Since I have a copy of the certificate, I know who the issuer is
			// So if the signature is valid I then it was sent from the right place (probably).
			//var certificateNode = signNode.SelectSingleNode(".//ds:X509Certificate", ns);
			//var Certificate = new X509Certificate2(System.Text.Encoding.UTF8.GetBytes(certificateNode.InnerText));
			// checking signature
			bool isSigned = signedXml.CheckSignature(Certificate, true);
			if (!isSigned)
			{
				throw new Exception("Certificate and signature mismatch!");
			}
			// If you extracted the signature, you would check the issuer here
			// Here is the validation of the response
			// Some of this might be unnecessary in your case, or might not be enough (especially if you plan to use SAML for more than just SSO)
			var statusNode = responseNode.SelectSingleNode("samlp:Status/samlp:StatusCode", ns);
			if (statusNode.Attributes["Value"].Value != "urn:oasis:names:tc:SAML:2.0:status:Success")
			{
				throw new Exception("Incorrect status code!");
			}
			var conditionsNode = assertionNode.SelectSingleNode("saml:Conditions", ns);
			var audienceNode = conditionsNode.SelectSingleNode("//saml:Audience", ns);
			if (audienceNode.InnerText != "Name of your app on the IDP")
			{
				throw new Exception("Incorrect audience!");
			}
			var startDate = XmlConvert.ToDateTime(conditionsNode.Attributes["NotBefore"].Value, XmlDateTimeSerializationMode.Utc);
			var endDate = XmlConvert.ToDateTime(conditionsNode.Attributes["NotOnOrAfter"].Value, XmlDateTimeSerializationMode.Utc);
			if (DateTime.UtcNow < startDate || DateTime.UtcNow > endDate)
			{
				throw new Exception("Conditions are not met!");
			}
			var fields = new Dictionary<string, string>();
			var userId = assertionNode.SelectSingleNode("//saml:NameID", ns).InnerText;
			var userName = assertionNode.SelectSingleNode("//saml:Attribute[@Name=\"urn:oid:1.2.840.113549.1.9.1\"]/saml:AttributeValue", ns).InnerText;
			// you can also extract some of the other fields in similar fashion
			var result = new AuthenticationResult(true, ProviderName, userId, userName, fields);
			return result;
		}
	}
