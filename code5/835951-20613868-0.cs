    public partial class Program
	{
		protected override void Execute()
		{
			var message1 = Encoding.UTF8.GetBytes("Hello there,");
			var message2 = Encoding.UTF8.GetBytes("Hello there");
			var signed = SignData(message1);
			var notOK = VerifyData(message2, signed);
			var oK = VerifyData(message1, signed);
		}
		public static byte[] SignData(byte[] message)
		{
			byte[] byteSignature2;
			var param = new CspParameters
			            {
				            KeyContainerName = "SignatureContainer101"
			            };
			using (var rsa = new RSACryptoServiceProvider(param))
			{
				rsa.PersistKeyInCsp = true;
				var byteSignature = rsa.SignData(message, "SHA256");
				byteSignature2 = byteSignature;
			}
			return byteSignature2;
		}
		public static bool VerifyData(byte[] originalMessage, byte[] signedMessage)
		{
			bool isSuccess;
			var param = new CspParameters
			            {
				            KeyContainerName = "SignatureContainer101"
			            };
			using (var rsa = new RSACryptoServiceProvider(param))
				isSuccess = rsa.VerifyData(originalMessage, "SHA256", signedMessage);
			return isSuccess;
		}
	}
