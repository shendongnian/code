    private static object _imageLock = new object();
    static void LargeComputation ()
      {
         lock(_imageLock)
         {
           image=new Bitmap(backupimage);
           //Long image processing ...
         }
      }
      static void AnotherImageOperationSomewhereElse()
      {
           lock(_imageLock)
           {
              //Another image processing on backupImage or something derived from it...
           }
      }
