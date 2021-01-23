    public void FindFieldNames<T>(List<T> data)
    {
          foreach (var prop in data.GetType().GetProperties())
          {           
               Console.WriteLine($@"{prop.Name}");                
          }    
    }
