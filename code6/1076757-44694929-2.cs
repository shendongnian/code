    //...
      using (var response = request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          using (var reader = new StreamReader(stream))
          {
            while (reader.Peek() != -1) //use Peek instead
            {
              Console.WriteLine(reader.ReadLine());
            }
          }
        }
      }
    //...
