    Class A
    {
    ...
    }
    
    Class C
    {
     ....
    }
    
    Class B
    {
      A a = (A)getJSONClass(String jsonString, typeof(A));
      C c = (C)getJSONClass(String jsonString, typeof(C));
    
      public object getJSONClass(String jsonString, Type type)
      {
       MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
       DataContractJsonSerializer ser = new DataContractJsonSerializer(type);
       return ser.ReadObject(memoryStream);
      }
    }
