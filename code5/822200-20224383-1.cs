    private void LoadWebService(object sender, RoutedEventArgs e)
        {
          var service =  new Service1Client();
          service.getRecommendPlaceAsync(new getRecommendPlaceRequest { activityId = 1}); //Provide your id here
          service.getRecommendPlaceCompleted += new EventHandler<MyCloundService.getRecommendPlaceCompletedEventArgs>(RecommendedPlaceRequestComplete);
        }
        void RecommendedPlaceRequestComplete(object sender, MyCloundService.getRecommendPlaceCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var result = String.Join(",", (from place in e.Result.getRecommendPlaceResult select place.Name).ToArray());
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("An error occured: " + e.Error.Message);
            }
        }
