    HypProperties obj=new HypProperties (){contentText="",Height=height,Width=width};
    if(!IsolatedStorageSettings.ApplicationSettings.Contains("KeyName"))
    {
    IsolatedStorageSettings.ApplicationSettings["KeyName"]=obj;
    IsolatedStorageSettings.ApplicationSettings.Save();
    }
