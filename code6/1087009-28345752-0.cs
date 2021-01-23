    public class MyService
    {
      private MyService() { }
      public static async Task<MyService> CreateAsync()
      {
        var result = new MyService();
        result.Value = await ...;
        return result;
      }
    }
