    public static Task<List<T>> getListOfAnyObject<T>(string requested_object) 
    {
       return Task.Factory.StartNew (() => {
           try {
               var request = CreateRequest (requested_object);
               string response = ReadResponseText (request);
               return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>> (response); // not sure how to handle this line
           } catch (Exception ex) {
               Console.WriteLine (ex);
               return ex.Message;
           }
       });
    }
