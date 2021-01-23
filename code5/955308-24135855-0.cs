        get{
            lock (locker){
               if (CacheHelper.Exists("MyData") == false){
                    if (CacheHelper.Exists("MyData") == true){
                        myData=(List<SomeDataDto>)CacheHelper.GetCacheObject("MyData");
                    }
                    else
                    if (CacheHelper.Exists("MyData") == false){
                        var myData = GetSomethingFromDatabase("en", true);
                    CacheHelper.Add(myData, "MyData", 360);
                }
              }
             return (List<SomeDataDto>)CacheHelper.GetCacheObject("MyData");
           }
        }
