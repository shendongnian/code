    static void Main(string[] args)
    {
      using (AcumenProjectsDBDataContext acumenResponse = new AcumenProjectsDBDataContext()) 
      {
        IEnumerable<Response> responseData = from response in acumenResponse.Responses select response; 
        //added code
         foreach (Response response in responseData)
         {
            foreach (PropertyInfo prop in response.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
              object value = prop.GetValue(response, new object[] { });
              Console.WriteLine("{0} = {1}", prop.Name, value);
            }
          }
          Console.ReadKey();
       }
    }
    
