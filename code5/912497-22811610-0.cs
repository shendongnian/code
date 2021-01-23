    class ManagerContact
    {
      private ManagerContact(int contactId)
      {
        ...
      }
      private async Task InitializeAsync()
      {
        await getDataAsync();
        ...
      }
      public static async Task<ManagerContact> CreateAsync(int id)
      {
        var result = new ManagerContact(id);
        await result.InitializeAsync();
        return result;
      }
    }
