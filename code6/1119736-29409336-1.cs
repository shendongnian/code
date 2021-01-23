    var N = JSON.Parse (generatedJSON);
	var csp = new RSACryptoServiceProvider(1024);
	csp.FromXmlString (N ["publickey"]);
	var plainTextData = "Hello from Web Player";
	var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);
	var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);
	var cypherText = Convert.ToBase64String(bytesCypherText);
