    public override Task Update() // Note: not "async"
    {
      foo.DoThings();
      if (someCondition) {
        return UpdateAsync();
      }
      else {
        return TaskConstants.Completed;
      }
    }
    async Task UpdateAsync()
    {
      // Get data, but let the server continue in the mean time
      var newFoo = await GetFooFromDatabase();
      // Now back on the main thread, update game state
      this.foo = newFoo;
    }
