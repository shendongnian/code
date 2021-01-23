    async private void SendRawMessage(string message) {
    	var writer = new DataWriter(_clientSocket.OutputStream);
    	writer.WriteString(message + "\r\n");
    	await writer.StoreAsync();
    	await writer.FlushAsync();
    	writer.DetachStream();
        if (!_closing) return;
        _clientSocket.DisposeSafe();
        _connected = false;
    }
