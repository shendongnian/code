     private static string mStringSetting;
     public static string AStringSetting { 
         get{
             lock(mThreadLock) { return mStringSetting; }
         } 
         set {
             lock(mThreadLock) { mStringSetting = value; }
         }
     }
     private static int mIntSetting;
     public static int AIntSetting { 
         get{
             lock(mThreadLock) { return mIntSetting; }
         } 
         set {
             lock(mThreadLock) { mIntSetting = value; }
         }
     }
     private static Object mThreadLock = new Object();
     public static void IncreaseIntIfLowerThan10AndStringIsTest()
     {
         lock(mThreadLock)
         {
             if (AStringSetting.Equals("TEST"))
             {
                 // AStringSettig is still "TEST", no other thread can change it due to the lock
                 if (AIntSetting < 10)
                 {
                     AIntSetting = AIntSetting + 1;
                 }
             }
         }
     }
