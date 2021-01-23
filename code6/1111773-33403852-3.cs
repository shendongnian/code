    public delegate void Callback<T>(T value);
    
    void MyCodeWorkflow()
    {
       //Doing somehing...
       PlayUnityVideoAd(delegate(bool result)
       {
         if (result)
         {
           //Something
         }
         else
         {
           //Something else
         }
       });
    }
