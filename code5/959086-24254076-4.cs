    using (var pcStream = new ProducerConsumerStream(BufferSize))
    {
        // start upload in a thread
        var uploadThread = new Thread(UploadThreadProc(pcStream));
        uploadThread.Start();
        // Open the input file and attach the gzip stream to the pcStream
        using (var inputFile = File.OpenRead("inputFilename"))
        {
            // create gzip stream
            using (var gz = new GZipStream(pcStream, CompressionMode.Compress, true))
            {
                var bytesRead = 0;
                var buff = new byte[65536]; // 64K buffer
                while ((bytesRead = inputFile.Read(buff, 0, buff.Length)) != 0)
                {
                    gz.Write(buff, 0, bytesRead);
                }
            }
        }
        // The entire file has been compressed and copied to the buffer.
        // Mark the stream as "input complete".
        pcStream.CompleteAdding();
        // wait for the upload thread to complete.
        uploadThread.Join();
        // It's very important that you don't close the pcStream before
        // the uploader is done!
    }
  
