     private async void Foo()
     {
 
            try
            {
                  await LongRunningMethod();
            }
            catch(Exception)
            {
                  //This is now safe, the exception will be caught, although admittedly  
                  // ugly code, better to have it in the called IMO.
            }
     }
