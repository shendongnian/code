    NetworkStream stream = client.GetStream();
    StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
    writer.AutoFlush = false;
    writer.Write(doc.Value.Length); //is this line intended? Take it out, see what happens!
    writer.Write(doc.Value);
    writer.Flush();
    writer.Write(data, 0, data.Length);
