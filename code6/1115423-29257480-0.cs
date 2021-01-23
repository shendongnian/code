    try
    {
      await _manager.RunCalcsCustomFactory(int.Parse(textTasksToCreate.Text), int.Parse(textMaxThreads.Text), cancelSource.Token, new Progress<string>(UpdateStatus), new Progress<int>(UpdateProgress));
    }
    catch (OperationCanceledException)
    {
      TasksComplete();
    }
    catch (Exception ex)
    {
      ProcessError();
    }
    UpdateStatus("Done");
