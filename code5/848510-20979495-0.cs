	private void Click(object sender, RoutedEventArgs e) {
			ServiceClient sc = new ServiceClient();
			using (OperationContextScope scope = new OperationContextScope(sc.InnerChannel)) {
				HttpRequestMessageProperty request = new HttpRequestMessageProperty();
				request.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " + EncodeBasicAuthenticationCredentials("test", "test123");
				OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, request);
				sc.setPushUriAsync(pushChannel.ChannelUri.ToString());
				}
	}
	private string EncodeBasicAuthenticationCredentials(string username, string password) {
		string credentials = username + ":" + password;
		var asciiCredentials = (from c in credentials
								select c <= 0x7f ? (byte)c : (byte)'?').ToArray();
		return Convert.ToBase64String(asciiCredentials);
	}
