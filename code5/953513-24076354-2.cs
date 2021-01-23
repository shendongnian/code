    public static void DisposeCommunicationObject(ICommunicationObject communicationObject)
    {
      if (communicationObject != null)
      {
        try
        {
          communicationObject.Close();
        }
        catch
        {
          communicationObject.Abort();
        }
        finally
        {
          ((IDisposable)communicationObject).Dispose();
        }
      }
    }
