    using (Stream st = new MemoryStream())
    { 
        ProtoBuf.Serializer.Serialize(st, oldMsg);
        st.Position = 0;          // point to start of stream
        var newMsg = ProtoBuf.Serializer.Deserialize<Message>(st);
    }
