    public async void SendDataMessage(string discoveryMessage)
    {
        // Get an output stream to all IPs on the given port
        using (var stream = await socket.GetOutputStreamAsync(new HostName("255.255.255.255"), udpPort))
        {
            // Get a data writing stream
            using (var writer = new DataWriter(stream))
            {
                // Write the string to the stream
                writer.WriteString(discoveryMessage);
                // Commit
                await writer.StoreAsync();
            }
        }
    }
