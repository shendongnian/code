    var command = "touch '/mnt/extsd/someFile'";
    
    using (var process = new JL.ProcessBuilder().Command("su", "-c", command)
                                                .RedirectErrorStream(true)
                                                .Start())
    {
        var buffer = new byte[256];
        var read = 0;
    
        do
        {
            read = process.InputStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer, 0, read));
        } while (read > 0);                        
    }
