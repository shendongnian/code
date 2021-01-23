    public async void Method()
    {
      bool updated = false;
      Parallel.ForEach(Feeds, feed => 
      {
        if (feed.Update())
            updated = true; // At least one feed was updated
      });
      if (updated)
      {
        // Do Something
      }
    }
