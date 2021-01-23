    byte[] myResponse;
    using (WebResponse response = request.GetResponse())
    {
        Stream responseStream = response.GetResponseStream();
        myResponse = ReadFully(responseStream);//done with the stream now and dispose it
        msg.Attachments.Add(new Attachment(Encoding.ASCII.GetString(myResponse), dictIterator.Key));
    }
    client.Send(msg);
