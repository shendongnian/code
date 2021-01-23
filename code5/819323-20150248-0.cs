            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            Queue<IYodas> q = new Queue<IYodas>();
            q.Enqueue(new Yoda());
            q.Enqueue(new Yoda2());
            formatter.Serialize(stream, q);
            Byte[] package = stream.ToArray();
           // Send broker message using package as the object to send
           ....
            // Then on the other end (you will need a byte array to object function)
            Queue<IYodas> result = (Queue<IYodas>)ByteArrayToObject(package);
