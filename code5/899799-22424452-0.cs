    public async Task<ActionResult> Poll()
    {
      while (!IsCompleted)
      {
        await Task.Delay(TimeSpan.FromSeconds(5));
        PartialView("PleaseWait").ExecuteResult(ControllerContext);
        Response.Flush();
      }
      return PartialView("Done");
    }
