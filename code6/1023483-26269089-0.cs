        private void OnQuerySubmitted(object sender, SearchPaneQuerySubmittedEventArgs args)
        {
            // Get frame information about the currently visible window. 
            Frame frame = Window.Current.Content as Frame;
            // If the current frame is not valid, do not continue
            if (frame == null)
            {
                return;
            }
            // Based on who the base frame is, call the process query handler for the proper frame....
            if ((typeof(A.MainPage) == frame.CurrentSourcePageType)
            {
               // do something
            }
            else if ((typeof(A.MainPage2) == frame.CurrentSourcePageType)
            {
               // do something
            }
            // and so on
