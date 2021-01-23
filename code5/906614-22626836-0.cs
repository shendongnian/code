    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(jsonClass )); 
    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)); 
    jsonClass obj = (jsonClass )ser.ReadObject(stream);
