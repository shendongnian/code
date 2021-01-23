    // Read the file
    string fileContents = string.Empty;
    using (System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\Path_to_File.txt"))
    {
        fileContents = rd.ReadToEnd();
    }
    
    // Deserialize
    RestResponse<T> restResponse = new RestResponse<T>();
    restResponse.Content = fileContents;
    RestSharp.Deserializers.JsonDeserializer deserializer = new RestSharp.Deserializers.JsonDeserializer();
    
    T deserializedObject = deserializer.Deserialize<T>(restResponse);
    
