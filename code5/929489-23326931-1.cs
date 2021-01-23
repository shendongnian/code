      try
      {
          ToUsers = (List<user>)Ser.Deserialize(ToStream);
          ToStream.Seek(0, SeekOrigin.Begin);
          ToUsers.Add(lastuser);
          Ser.Serialize(ToStream, ToUsers);
      }
 
