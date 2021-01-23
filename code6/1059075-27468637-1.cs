    JObject Data = Message.MessageData; 
    Type type = Message.MessageType;
    object obj = Data.ToObject(type); // if you dont know the type in compile time
    
    MyType obj2 = Data.ToObject<MyType>(); // if you know the type in compile time
