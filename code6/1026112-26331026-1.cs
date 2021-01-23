       void PhotoConfirmationCaptured(MediaCapture sender, PhotoConfirmationCapturedEventArgs args)
       {
       using (ManualResetEventSlim evt = new ManualResetEventSlim(false))
       {
           Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
           {
               try
               {
                   WriteableBitmap bmp = new WriteableBitmap(unchecked((int)args.Frame.Width), unchecked((int)args.Frame.Height));
                   using (var istream = args.Frame.AsStream())
                   using (var ostream = bmp.PixelBuffer.AsStream())
                   {
                       await istream.CopyStreamToAsync(ostream);
                   }
               }
               finally
               {
                   evt.Set();
               }
           });
           evt.Wait();
       }
