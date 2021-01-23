     void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            ApplicationViewState viewState = ApplicationView.Value;
           if (viewState == ApplicationViewState.Snapped)
            {
                //Navigate to the new common snap page
            }          
          else{
                  //Write the code to check if the previous state was snapped and then navigate back
            }
       }
