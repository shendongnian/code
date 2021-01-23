    static async Task<string> CallWcfAsync(int i)
    {
      using (ServiceReference1.Client client = new AsyncTests.ServiceReference1.Client())
      {
        return await client.GetThisIntAsync(i);
      }
    }
