    public async Task MyPatientCallingMethodAsync(...)
    {
      // 1. call the method
      var task = ThirdPartyAsync(...);
      // 2. wait for ThirdPartyAsync to finish
      await task;
      // 3. return after
      return;
    }
