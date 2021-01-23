    private Task HandleClientAsync(TcpClient client)
    {
        // Note: this uses a *synchronous* call to create the file; not ideal.
        using (var output = File.Create("client.data"))
        {
            using (var input = client.GetStream())
            {
                // Could use CopyToAsync... this is just demo code really.
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await output.WriteAsync(buffer, 0, bytesRead);
                }
            }
        }
    }
