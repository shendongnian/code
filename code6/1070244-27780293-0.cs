        private async void App_Resuming(object sender, object e)
        {
            var x1 = new SolidColorBrush((Color)Application.Current.Resources["PhoneForegroundColor"]);
            Debug.WriteLine(x1?.Color.ToString());
            // Await marshalls back to the ui thread,
            // so it gets put into the dispatcher queue
            // and is run after the resuming has finished.
            await Task.Delay(1);
            var x2 = new SolidColorBrush((Color)Application.Current.Resources["PhoneForegroundColor"]);
            Debug.WriteLine(x2?.Color.ToString());
        }
