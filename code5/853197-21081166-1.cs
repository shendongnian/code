    private void Application_Closing
    {
       //objSaveData = null;  // no use
       IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
       ... use it to save something
    }
    
    public class objSaveData
    {
    // destructors are called in an unpredictable fashion, usually too late. 
    //    ~objSaveData
    //    {
    //      try
    //      { 
    //         IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
    //      }
    // empty catch blocks hide errors, don't do this
    //      catch
    //      {
    //      }
    //    }
    }
