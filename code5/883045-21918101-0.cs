    ctx.Cache.Insert("stmodel", stModel, null,
                 MyClass.getSpecificDateTime(), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, OnCachedItemRemoved);
     public static DateTime getSpecificDateTime()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            DateTime newTime = DateTime.Now;
            if (currentTime.Hours < 7){
                newTime = newTime.Date + new TimeSpan(7, 0, 0);
            }else if (currentTime.Hours < 11){
                newTime = newTime.Date + new TimeSpan(11, 0, 0);
            }else if (currentTime.Hours < 15) {
                newTime = newTime.Date + new TimeSpan(15, 0, 0);
            }else if (currentTime.Hours < 19){
                newTime = newTime.Date + new TimeSpan(19, 0, 0);
            }else {
                newTime = DateTime.Now.AddDays(1);
                newTime = newTime.Date + new TimeSpan(7, 0, 0);
            }   
            return newTime;
        }
