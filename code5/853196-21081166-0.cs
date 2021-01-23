    private void Application_Closing
    {
       //objSaveData = null;
       IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
       ... use it somehow
    }
    
    public class objSaveData
    {
    //    ~objSaveData
    //    {
    //      try
    //      { 
    //         IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
    //      }
    //      catch
    //      {
    //      }
    //    }
    }
