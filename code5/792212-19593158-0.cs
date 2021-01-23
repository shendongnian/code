        Response.BufferOutput = false; //sets chunked encoding
        Response.ContentType = "audio/mpeg";
        using (var bw = new BinaryWriter(Response.OutputStream))
        {
            foreach (DataChunk leChunk in db.Mp3Files.First(mp3 => mp3.Mp3ResourceId.Equals(id)).Data.Chunks.OrderBy(chunk => chunk.ChunkOrder))
            {
                if (Response.IsClientConnected) //avoids the host closed the connection exception
                {
                    bw.Write(leChunk.Data); 
                }
            }
        }
