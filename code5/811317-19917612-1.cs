    private async void HandleClosed(object sender, EventArgs e)
    {
        var list = new[]
      {
          _service.ExecuteAsync("first task"),
          _service.ExecuteAsync("second task"),
          _service.ExecuteAsync("third task")
      };
        //uncommenting this line blocks all three previous activities as expected
        //as it drives the current main thread to wait for other tasks waiting to be executed by the main thread.
        await TaskEx.WhenAll(list);
    }
