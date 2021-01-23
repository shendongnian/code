        public byte[] Serialize()
        {
            //Data will be serialized in the format 
            //  - MessageType (1 byte)
            //  - Body (x Bytes)
    
            //We allocate a fixed buffer as we know the size already.
            var data = new byte[Body.Length + 1];
    
            data[0] = (byte)this.MessageType;
            //We copy the data from Body in to data starting at index 1 in data.
            Array.Copy(Body, 0, data, 1, Body.Length);    
            return data;
        }
        public static Message Deserialize(byte[] data)
        {
            var message = new Message();
            
            //We do the same order of operations.
            message.MessageType = (MessageType)data[0];
            //Create a new array and copy the body data in to it.
            var body = new byte[data.Length - 1];
            Array.Copy(data, 1, body, 0, data.Length - 1);
            //Assign the body array to the property.
            message.Body = body;
    
            return message;
        }
    }
