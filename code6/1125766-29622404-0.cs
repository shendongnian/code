        public void pickOneVideo(string options) {
            try {
 
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
                openPicker.FileTypeFilter.Add(".wmv");
                openPicker.FileTypeFilter.Add(".mp4");
                openPicker.FileTypeFilter.Add(".wma");
                openPicker.FileTypeFilter.Add(".mp3");
                openPicker.PickSingleFileAndContinue();
                
                view.Activated += viewActivated; 
            }            
            catch (Exception e) {
                Debug.WriteLine("e: " + e.Message);
            }
            
             
            // return path video
            //DispatchCommandResult(new PluginResult(PluginResult.Status.OK, "path del video"));
        }
        private void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            Debug.WriteLine("viewActivated ----");
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;
            if (args != null)
            {
                if (args.Files.Count == 0) return;
                view.Activated -= viewActivated;
                 Debug.WriteLine("args: " + args.Files[0].Name);
             }
        }
