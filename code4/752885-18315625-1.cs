C#
public static async Task WithAggregateException(this Task source)
{
  try
  {
    await source.ConfigureAwait(false);
  }
  catch
  {
    // source.Exception may be null if the task was canceled.
    if (source.Exception == null)
      throw;
    // EDI preserves the original exception's stack trace, if any.
    ExceptionDispatchInfo.Capture(source.Exception).Throw();
  }
}
