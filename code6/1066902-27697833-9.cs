    // this is server side
    using (var stream = new MemoryStream(bytes))
    {
       Int32 messageSize;
    
       // if we have a valid package do stuff
       // this loops until there isnt enough data for a package or empty
       while (stream.HasValidPackage(out messageSize))
       {
    
          byte[] buffer;
    
          switch (stream.UnPackMessage(messageSize, out buffer))
          {
             case MessageType.MyClass:
                var myClassCopy = buffer.DeserializeFromBytes<MyClass>();
                // do stuff with your class
                break;
             case MessageType.MyOtherClass:
                break;
             case MessageType.Message3:
                break;
             case MessageType.Message4:
                break;
             default:
                throw new ArgumentOutOfRangeException();
          }
    
       }
       
       // do something with the remaining bytes here, if any, i.e partial package
    }
